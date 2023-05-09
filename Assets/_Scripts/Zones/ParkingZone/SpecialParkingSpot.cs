using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpecialParkingSpot : ParkingSpot
{
    [SerializeField] GameObject prevVisuals;
    [SerializeField] Transform posT;
    [SerializeField] SpecialParkingTrigger sParkingTrigger;
    [SerializeField] Transform exitSpot;
    [SerializeField] TMP_Text capacityText;

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

    public override void ActivateVisuals()
    {
        if (!visuals.activeSelf)
        {
            prevVisuals.SetActive(false);
            visuals.SetActive(true);
        }
    }

    public override void UpdateVisuals(int actualCapacity)
    {
        int extra = (capacity == Count) ? 0 : -1;
        Debug.Log(capacity == Count);
        int numberToShow = actualCapacity + (capacity - Count) + extra;
        capacityText.text = numberToShow.ToString();
    }
}
