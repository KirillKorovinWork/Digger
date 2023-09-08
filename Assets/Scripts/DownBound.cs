using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBound : MonoBehaviour
{
    private Transform spawnPoint;

    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
    }

    void Update()
    {
        if(transform.position.y <= -2)
        {
            transform.position = spawnPoint.position;
        }
    }
}
