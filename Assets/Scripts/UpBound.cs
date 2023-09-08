using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBound : MonoBehaviour
{
   public float restrictionNumber = 30.0f;

    void Update()
    {
        if(transform.position.x > restrictionNumber)
        {
            transform.position = new  Vector3(restrictionNumber, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -restrictionNumber)
        {
            transform.position = new  Vector3(-restrictionNumber, transform.position.y, transform.position.z);
        }
        if(transform.position.z > restrictionNumber)
        {
            transform.position = new  Vector3(transform.position.x, transform.position.y, restrictionNumber);
        }
        if(transform.position.z < -restrictionNumber)
        {
            transform.position = new  Vector3(transform.position.x, transform.position.y, -restrictionNumber);
        }
    }
}
