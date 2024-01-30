using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Vehicle vehicle = other.GetComponent<Vehicle>();

        if(vehicle != null)
        {
            
            vehicle.GetComponent<Vehicle>().Speed = transform.parent.GetComponent<Vehicle>().Speed;
        }
    }
}
