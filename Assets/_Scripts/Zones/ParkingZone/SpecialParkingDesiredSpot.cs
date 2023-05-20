using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialParkingDesiredSpot : MonoBehaviour
{
    Vector3 pos;

    private void Awake()
    {
        pos = GetComponentInParent<SpecialParkingSpot>().ExitSpotPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ClientExit"))
        {
            other.GetComponent<AgentBase>().SetDestination(pos);
        }
    }
}
