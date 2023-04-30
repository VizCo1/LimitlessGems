using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    [SerializeField] ParkingZone zoneManager;
    [SerializeField] int capacity;
    [HideInInspector] public int Count = 0;
    public bool isSpecial = false;
    [HideInInspector] public List<GameObject> actualClients;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") && other.gameObject == actualClients.Contains(other.gameObject))
        {           
            Client client = other.GetComponent<Client>();
            client.ParkCar();
        }
        else if (other.CompareTag("ClientExit") && actualClients.Contains(other.gameObject))
        {
            Client client = other.GetComponent<Client>();
            client.UnParkCar();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CarExit"))
        {
            actualClients.Remove(other.gameObject);
            other.GetComponent<Client>().ChangeTag("CarExit2");
            zoneManager.AddFreeSpot(this);
            //DOVirtual.DelayedCall(3f, () => zoneManager.AddFreeSpot(this));
        }
    }

    public int Capacity()
    {
        return capacity;
    }

    public void IncreaseCapacity()
    {
        capacity++;
    }
}
