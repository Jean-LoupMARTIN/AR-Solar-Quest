using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astre : MonoBehaviour
{
    public float tRot; // sec
    float tOrbite;
    public Transform body, orbiteCenter, orbiteAxe;
    public ParticleSystem trail;

    bool discovered;
    public Circle shadow;
    public List<GameObject> satellites;


    private void Start()
    {
        discovered = !shadow;

        if (!discovered)
        {
            shadow.gameObject.SetActive(true);
            if (orbiteCenter) {
                shadow.radius = Tool.Dist(transform, orbiteCenter) / shadow.transform.lossyScale.x;
                shadow.center = orbiteCenter;
                shadow.Draw();
            }
            

            body.gameObject.SetActive(false);
            foreach (GameObject satellite in satellites)
                satellite.SetActive(false);

            SolarSystem.inst.unknowAstres.Add(this);
        }


        if (orbiteCenter)
        {
            float distOrbiteCenter = Tool.Dist(transform, orbiteCenter);
            tOrbite = distOrbiteCenter * 100;
            if (trail) trail.startLifetime = tOrbite;
        }
    }



    void Update()
    {
        if (!discovered) return;

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



    public void Discorver()
    {
        if (discovered) return;

        discovered = true;
        shadow.gameObject.SetActive(false);
        body.gameObject.SetActive(true);
        foreach (GameObject satellite in satellites)
            satellite.SetActive(true);
    }
}
