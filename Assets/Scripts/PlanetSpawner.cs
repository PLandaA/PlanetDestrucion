using System.Collections;
using UnityEngine;

/// <summary>Endless-mode factory: picks the planet type (difficulty-weighted), finds a safe position and wires chasers to a target.</summary>
public class PlanetSpawner : MonoBehaviour
{
    [Header("Planet prefabs")]
    [SerializeField] GameObject [] wandererPrefabs;
    [SerializeField] GameObject [] chaserPrefabs;

    [Header("Spawn timing")]
    [SerializeField] float firstSpawnDelay = 10f;
    [SerializeField] float startInterval = 12f;
    [SerializeField] float minInterval = 4f;
    [SerializeField] float secondsToMaxDifficulty = 150f;

    [Header("Difficulty mix")]
    [Range(0f, 1f)] [SerializeField] float chaserChanceAtStart = 0.1f;
    [Range(0f, 1f)] [SerializeField] float chaserChanceAtMax = 0.5f;
    [SerializeField] int maxPlanets = 12;

    [Header("Placement")]
    [SerializeField] Vector2 spawnAreaMin = new Vector2(-7f, -3.5f);
    [SerializeField] Vector2 spawnAreaMax = new Vector2(7f, 3.5f);
    [SerializeField] float minDistanceToOthers = 2f;

    GameManager manager;

    void Start ()
    {
        manager = FindFirstObjectByType<GameManager>();
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop ()
    {
        yield return new WaitForSeconds(firstSpawnDelay);

        while (true)
        {
            if (manager == null || !manager.HasLost)
            {
                TrySpawnPlanet();
            }

            yield return new WaitForSeconds(Mathf.Lerp(startInterval, minInterval, Difficulty()));
        }
    }

    float Difficulty ()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }

    void TrySpawnPlanet ()
    {
        PlanetMovement [] planets = FindObjectsByType<PlanetMovement>(FindObjectsSortMode.None);
        if (planets.Length >= maxPlanets)
        {
            return;
        }

        // No fair spot this cycle: skip rather than spawn an unfair instant collision.
        if (!TryFindSafePosition(planets, out Vector2 position))
        {
            return;
        }

        bool spawnChaser = planets.Length > 0 && chaserPrefabs.Length > 0 &&
                           Random.value < Mathf.Lerp(chaserChanceAtStart, chaserChanceAtMax, Difficulty());

        GameObject prefab = spawnChaser
            ? chaserPrefabs [Random.Range(0, chaserPrefabs.Length)]
            : wandererPrefabs [Random.Range(0, wandererPrefabs.Length)];

        GameObject planet = Instantiate(prefab, position, Quaternion.identity);

        if (spawnChaser)
        {
            planet.GetComponent<MoveTowards>().otherPlanet =
                planets [Random.Range(0, planets.Length)].transform;
        }
    }

    bool TryFindSafePosition (PlanetMovement [] planets, out Vector2 position)
    {
        for (int attempt = 0; attempt < 20; attempt++)
        {
            position = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y));

            bool safe = true;
            foreach (PlanetMovement other in planets)
            {
                if (Vector2.Distance(position, other.transform.position) < minDistanceToOthers)
                {
                    safe = false;
                    break;
                }
            }

            if (safe)
            {
                return true;
            }
        }

        position = Vector2.zero;
        return false;
    }
}
