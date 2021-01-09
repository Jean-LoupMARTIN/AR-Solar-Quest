using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SolarSystem : MonoBehaviour
{
    public static SolarSystem inst;

    [Range(0, 5)]
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
