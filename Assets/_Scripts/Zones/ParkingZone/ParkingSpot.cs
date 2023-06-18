using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    [SerializeField] protected ParkingZone zoneManager;
    [SerializeField] protected int capacity;
    [SerializeField] protected GameObject visuals;
    [HideInInspector] public int Count = 0;
    public bool isSpecial = false;
    [HideInInspector] public List<GameObject> actualClients;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") && other.gameObject == actualClients.Contains(other.gameObject))
        {           
            Client client = other.GetComponent<Client>();
            client.ParkCar(Vector3.zero);
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

    public int Capacity() =>  capacity;

    public void SetCapacity(int capacity) => this.capacity = capacity;

    public virtual void IncreaseCapacity() => capacity++;
    

    public virtual void ActivateVisuals()
    {
        if (!visuals.activeSelf)
        {
            visuals.SetActive(true);
        }
    }

    public virtual void UpdateVisuals(int capacity)
    {

    }
}
