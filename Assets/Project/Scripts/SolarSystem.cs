using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SolarSystem : MonoBehaviour
{
    public static SolarSystem inst;

    public float speed = 1;
    public UnityEvent discoverEvent;
    public Transform pivot;

    void Awake()
    {
        inst = this;
    }


    public void Discover()
    {
        discoverEvent.Invoke();
    }
}
