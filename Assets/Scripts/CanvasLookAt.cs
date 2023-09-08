using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLookAt : MonoBehaviour
{
    private Transform player;

    void Start() 
    {
        player = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    void Update()
    {
        transform.LookAt(player);
    }
}
