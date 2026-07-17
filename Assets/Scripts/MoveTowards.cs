using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Transform otherPlanet;

    public float speed;

    public float minSpeed;
    public float maxSpeed;

    public float secondsToMaxDiff;

    void Update ()
    {
        // The other planet may already be destroyed after a collision.
        if (otherPlanet == null)
        {
            return;
        }

        speed = Mathf.Lerp(minSpeed, maxSpeed, changeDifficulty());
        transform.position = Vector2.MoveTowards(transform.position, otherPlanet.position, speed * Time.deltaTime);
    }

    float changeDifficulty () {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDiff);

    }

}
