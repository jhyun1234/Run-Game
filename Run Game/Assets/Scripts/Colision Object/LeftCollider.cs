using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollider : MonoBehaviour
{

    private bool detector;

    public bool Detector
    {
        get { return detector; }
    }
    private void OnTriggerStay(Collider other)
    {
        Vehicle vehicle = other.GetComponent<Vehicle>();
        if (vehicle != null)
        {
            detector = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        Vehicle vehicle = other.GetComponent<Vehicle>();
        if (vehicle != null)
        {
            detector = false;

        }
    }
}
