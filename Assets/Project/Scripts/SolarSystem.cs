using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SolarSystem : MonoBehaviour
{
    public static SolarSystem inst;

    public float rotSpeed, orbiteSpeed;
    public UnityEvent discoverEvent;
    /*
    public Transform planets, orbites;
    public Circle orbitePrefab;
    */

    void Awake()
    {
        inst = this;
        rotSpeed *= 100;
        orbiteSpeed *= 100;
        /*
        foreach (Transform planet in planets) {
            Circle orbite = Instantiate(orbitePrefab, transform.transform.position, orbitePrefab.transform.rotation, orbites);
            orbite.name = planet.name;
            orbite.radius = planet.transform.localPosition.x;
        }
        */
    }


    public void Discover()
    {
        discoverEvent.Invoke();
    }
}
