using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkUpwards : MonoBehaviour
{
    [SerializeField] bool parkUpwards;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            other.GetComponent<Client>().GetCar().parkUpwards = parkUpwards;
        }
    }
}
