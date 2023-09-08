using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsphaltSpawnPoint : MonoBehaviour
{
    [SerializeField] float countRepairPlaces;
    [SerializeField] GameObject asphaltPrefab;

    void Start()
    {
        countRepairPlaces = GameObject.FindGameObjectsWithTag("RepairPlace").Length;
        countRepairPlaces *= 3;

        for (int i = 0; i < countRepairPlaces; i++)
        {
            Instantiate(asphaltPrefab);
        }
    }
}
