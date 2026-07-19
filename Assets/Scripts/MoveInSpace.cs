using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInSpace : PlanetMovement
{
    
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 targetPosition;

    void Start()
    {
        targetPosition = getRandomPosition();
    }

    protected override void Move ()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            MoveTowardsTarget(targetPosition);
        }
        else
        {
            targetPosition = getRandomPosition();
        }
    }

    Vector2 getRandomPosition() {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

   

    }
