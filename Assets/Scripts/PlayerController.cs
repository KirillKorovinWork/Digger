using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Vehicle Settings")]

    [SerializeField] Transform wheelRF;
    [SerializeField] Transform wheelLF;
    [SerializeField] Transform wheelRB;
    [SerializeField] Transform wheelLB;

    [SerializeField] WheelCollider wheelColliderRF;
    [SerializeField] WheelCollider wheelColliderLF;
    [SerializeField] WheelCollider wheelColliderRB;
    [SerializeField] WheelCollider wheelColliderLB;

    public AudioSource[] vehicleSound;

    [SerializeField] float vehicleSpeed = 10f;
    [SerializeField] float vehicleRotationAngle = 10f;
    [SerializeField] float brakeTorquePress = 1500f;
    [SerializeField] float brakeTorqueZero = 0f;
    [SerializeField] float rotationFlipped = 40f;

    [Header("Flipped Button Settings")]

    [SerializeField] GameObject flippedCanvas;
    [SerializeField] Image buttonImage;
    [SerializeField] float buttonSpeedAnimation = 1f;
    [SerializeField] float fromBright;
    [SerializeField] float toBright;

    [Header("Bucket Settings")]

    [SerializeField] Transform bucketRotation;

    [SerializeField] float bucketRotationSpeed = 5f;
    [SerializeField] float rotationAngle = 0f;
    [SerializeField] float minBucketRotation = -9.0f;
    [SerializeField] float maxBucketRotation = -60.0f;

    [Header("Game Settings")]

    public bool vehicleOnParking = false;
    public BaseManager baseManager;

    private void Start()
    {
 
    }

    void FixedUpdate()
    {
        DriveController();
        BucketRotationController();
        //CarFlipped();
    }

    void DriveController()
    {
        wheelColliderRF.motorTorque = Input.GetAxis("Vertical") * vehicleSpeed;
        wheelColliderLF.motorTorque = Input.GetAxis("Vertical") * vehicleSpeed;

        if(Mathf.Abs(0.1f) > Input.GetAxis("Vertical"))
        {

        }
        else 
        {
            
        }

        if (Input.GetKey(KeyCode.Space)) 
        {
            wheelColliderRF.brakeTorque = brakeTorquePress;
            wheelColliderLF.brakeTorque = brakeTorquePress;
            wheelColliderRB.brakeTorque = brakeTorquePress;
            wheelColliderLB.brakeTorque = brakeTorquePress;


        }
        else 
        {
            wheelColliderRF.brakeTorque = brakeTorqueZero;
            wheelColliderLF.brakeTorque = brakeTorqueZero;
            wheelColliderRB.brakeTorque = brakeTorqueZero;
            wheelColliderLB.brakeTorque = brakeTorqueZero;


        }

        wheelColliderRF.steerAngle = Input.GetAxis("Horizontal") * vehicleRotationAngle;
        wheelColliderLF.steerAngle = Input.GetAxis("Horizontal") * vehicleRotationAngle;

        RotateWheel(wheelColliderRF, wheelRF);
        RotateWheel(wheelColliderLF, wheelLF);
        RotateWheel(wheelColliderRB, wheelRB);
        RotateWheel(wheelColliderLB, wheelLB);
    }

    void RotateWheel(WheelCollider collider, Transform transform) 
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        transform.rotation = rotation;
        transform.position = position;
    }

    void BucketRotationController()
    {
        rotationAngle += Input.mouseScrollDelta.y * bucketRotationSpeed;
        rotationAngle = Mathf.Clamp(rotationAngle, maxBucketRotation, minBucketRotation);
        
        bucketRotation.localEulerAngles = new Vector3(rotationAngle, 0, 0);

        //Mathf.Abs(transform.rotation.eulerAngles.z) > rotationFlipped || Mathf.Abs(transform.rotation.eulerAngles.x) > rotationFlipped
    }

    void CarFlipped() 
    {
        float zAngles = transform.rotation.eulerAngles.z;
        float xAngles = transform.rotation.eulerAngles.x;

        if (zAngles > rotationFlipped || zAngles < -rotationFlipped || xAngles > rotationFlipped || xAngles < -rotationFlipped)
        {
            flippedCanvas.SetActive(true);
            Debug.Log("Z: " + zAngles);
            Debug.Log("X: " + xAngles);

            if (Input.GetKeyDown(KeyCode.F)) 
            {
                transform.position = new Vector3(transform.position.x, 2, transform.position.z);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }else
        {
            flippedCanvas.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Parking") && baseManager.roadRepaired == true)
        {
            vehicleOnParking = true;
        }
    }
}
