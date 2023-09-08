using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseManager : MonoBehaviour
{
    [SerializeField] int countRepairPlaces;
    [SerializeField] int rRepairValue;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] PlayerController playerController;

    [SerializeField] bool win = false;
    public bool roadRepaired = false;

    [SerializeField] TextMeshProUGUI baseText;
    [SerializeField] TextMeshProUGUI missionText;
    void Awake()
    {
        countRepairPlaces = GameObject.FindGameObjectsWithTag("RepairPlace").Length;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        TasksUpdate(rRepairValue);
        GameWinSettings();
    }
    public void TasksUpdate(int roadRepairValue)
    {
        if (countRepairPlaces > 0) //The main condition of victory
        { 
            countRepairPlaces -= roadRepairValue;
            baseText.text = "Tasks: \n 1.Repair road: " + countRepairPlaces;
            missionText.text = "Tasks: \n 1.Repair road " + countRepairPlaces;
        }
        else 
        {
            roadRepaired = true;
            if (win != true)
            {
                baseText.text = "Tasks: \n Return to the Parking ";
                missionText.text = "Tasks: \n Return to the Parking ";
            }
        }
    }
    void GameWinSettings()
    {
        if (playerController.vehicleOnParking == true)
        {
            //Win
            winText.gameObject.SetActive(true);
            win = true;
        }
    }
}