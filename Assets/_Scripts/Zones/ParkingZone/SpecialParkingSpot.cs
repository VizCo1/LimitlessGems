using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialParkingSpot : ParkingSpot
{
    [SerializeField] Transform posT;
    [SerializeField] SpecialParkingTrigger sParkingTrigger;
    [SerializeField] Transform exitSpot;

    public Vector3 pos { get; private set; }

    private void Awake()
    {
        pos = posT.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") && other.gameObject == actualClients.Contains(other.gameObject))
        {
            Client client = other.GetComponent<Client>();
            client.agent.Warp(exitSpot.position);
            client.ParkCar();
        }
        else if (other.CompareTag("ClientExit") && actualClients.Contains(other.gameObject))
        {
            Client client = other.GetComponent<Client>();
            client.agent.Warp(client.GetCar().transform.position);
            client.UnParkCar();
        }
    }

    public SpecialParkingTrigger SpecialParkingTrigger()
    {
        return sParkingTrigger;
    }
}
