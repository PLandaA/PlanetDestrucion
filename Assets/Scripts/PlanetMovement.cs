using UnityEngine;

/// <summary>Template Method base: owns the difficulty-ramped movement skeleton; subclasses only decide where to move.</summary>
public abstract class PlanetMovement : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    public float secondsToMaxDiff;

    protected float speed;

    void Update ()
    {
        speed = Mathf.Lerp(minSpeed, maxSpeed, DifficultyRamp());
        Move();
    }

    protected abstract void Move ();

    protected void MoveTowardsTarget (Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    float DifficultyRamp ()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDiff);
    }
}
