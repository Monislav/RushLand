using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public GameObject enemy;
    public float speed;
    public Transform[] spawn;
    
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 10f, speed);
    }

    void Spawn()
    {
        for (int i = 0; i < spawn.Length; i++)
        {
            Instantiate(enemy, spawn[i].position, spawn[i].rotation);
        }
    }
}
