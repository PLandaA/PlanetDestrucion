using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : PlanetMovement
{
    public Transform otherPlanet;

    protected override void Move ()
    {
        // The other planet may already be destroyed after a collision.
        if (otherPlanet == null)
        {
            return;
        }

        MoveTowardsTarget(otherPlanet.position);
    }

    }
