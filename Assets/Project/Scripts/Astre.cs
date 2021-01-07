using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astre : MonoBehaviour
{
    public float tRot, tOrbite; // day
    public Transform orbiteCenter;

    private void Awake()
    {
        tOrbite = Mathf.Sqrt(tOrbite) * 20;

        Transform trail = transform.FindChild("Trail");
        if (trail) trail.GetComponent<ParticleSystem>().startLifetime = tOrbite / 35;
    }



    void Update()
    {
        transform.Rotate(0, -Time.deltaTime * SolarSystem.inst.rotSpeed / tRot, 0);

        if (orbiteCenter) {
            Quaternion rot = transform.rotation;
            transform.RotateAround(
                orbiteCenter.position,
                Vector3.up,
                -Time.deltaTime * SolarSystem.inst.orbiteSpeed / tOrbite);
            transform.rotation = rot;
        }
    }
}
