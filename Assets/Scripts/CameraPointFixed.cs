using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    
    [SerializeField] float yAxis = 10;
    [SerializeField] float zAxis = 3;

    void Update()
    {
        transform.Translate(0, yAxis, zAxis, Space.World);
    }
}

