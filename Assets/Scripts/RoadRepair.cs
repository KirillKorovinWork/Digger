using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RoadRepair : MonoBehaviour
{
    public TextMeshProUGUI repairText;
    public GameObject repairPlace;
    public GameObject repairCanvas;
    public GameObject repairPlacePoint;
    private BaseManager baseManager;
    private AudioSource repairAudio;

    public int amountToRepair = 3;
    public int amountForOneAsphalt = 1;
    public int totalCount = 0;

    [SerializeField] bool countUpdateSwitch = true;

    void Start()
    {
        repairAudio = repairPlacePoint.GetComponent<AudioSource>();
        baseManager = GameObject.Find("Base").GetComponent<BaseManager>();
        RepairUpdate(0);
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Asphalt"))
        {
            repairAudio.Play();
            RepairUpdate(amountForOneAsphalt);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        ChangeScale();
    }

    IEnumerator CountUpdate()
    {
        while (true)
        {
            RepairUpdate(amountForOneAsphalt);
        }
    }

    void RepairUpdate(int asphaltCounter)
    {
        totalCount += asphaltCounter;
        repairText.text = totalCount + "/" + amountToRepair;
        if(totalCount >= amountToRepair) 
        {
            baseManager.TasksUpdate(1);
            Destroy(gameObject);
            Destroy(repairCanvas);
            countUpdateSwitch = false;
        }
    }
    void ChangeScale()
    {
        switch(totalCount)
        {
            case 1:
                repairPlace.transform.localScale = new Vector3(0.2f, repairPlace.transform.localScale.y, repairPlace.transform.localScale.z);
                break;
            case 2:
                repairPlace.transform.localScale = new Vector3(0.1f, repairPlace.transform.localScale.y, repairPlace.transform.localScale.z);
                break;
        }
    }
}
