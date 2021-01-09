using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astre : MonoBehaviour
{
    public float tRot; // sec
    public ParticleSystem trail;
    public Transform orbiteCenter, orbiteAxe;
    Vector3 orbiteAxeForward;

    float startScale, distOrbite, tRev, pRev = 0;

    private void Awake()
    {
        if (orbiteCenter)
        {
            orbiteAxeForward = orbiteAxe.right;
            distOrbite = Tool.Dist(transform, orbiteCenter);
            startScale = transform.lossyScale.x;
            tRev = distOrbite * 100;
            if (trail) trail.startLifetime = tRev;
        }
    }

    void Update()
    {
        transform.Rotate(0, -360 * Time.deltaTime / tRot * SolarSystem.inst.speed, 0);

        if (orbiteCenter)
        {
            pRev += Time.deltaTime / tRev * SolarSystem.inst.speed;
            pRev %= 1;

            Transform pivot = SolarSystem.inst.pivot;
            pivot.position = orbiteCenter.position;
            Tool.LookDir(SolarSystem.inst.pivot, orbiteAxeForward);
            pivot.Rotate(0, -360 * pRev, 0);

            Vector3 pos = pivot.position + pivot.forward * distOrbite * transform.lossyScale.x / startScale;
            transform.position = pos;
        }
    }
}
