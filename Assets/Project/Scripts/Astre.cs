using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astre : MonoBehaviour
{
    public float tRot; // sec
    float tOrbite;
    public Transform body, orbiteCenter, orbiteAxe;
    public ParticleSystem trail;

    private void Awake()
    {
        if (orbiteCenter) {
            float distOrbiteCenter = Tool.Dist(transform, orbiteCenter);
            tOrbite = distOrbiteCenter * 100;
            if (trail) trail.startLifetime = tOrbite;
        }
    }

    void Update()
    {
        // rotation
        body.Rotate(0, -360 * Time.deltaTime / tRot * SolarSystem.inst.speed, 0);

        // orbite
        if (orbiteCenter)
        {
            Quaternion rotMem = transform.rotation;

            transform.RotateAround(
                orbiteCenter.position,
                orbiteAxe.up,
                -360 * Time.deltaTime / tOrbite * SolarSystem.inst.speed);

            transform.rotation = rotMem;
        }
    }
}
