using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GemType
{
    Ruby,
    Sapphire,
    Diamond
}

public class Client : AgentBase
{
    [SerializeField] Car car;
    [SerializeField] Material[] materials;
    [SerializeField] MeshRenderer meshRenderer;

    GemType chosenGem;

    private void OnEnable()
    {
        agent.Warp(transform.parent.position);
        index = 0;
        ChangeTag("Car");
        GoToNextPosition();
        ChooseGem();
        meshRenderer.material = materials[Random.Range(0, materials.Length)];
    }

    void ChooseGem()
    {
        // TODO -> Change probabilities, GameManager will do it
        chosenGem = (GemType)Random.Range(0, 3);
    }

    public void ParkCar()
    {
        car.Park();
        ChangeTag("Client");
        GoToNextPosition();
    }

    public void UnParkCar()
    {
        transform.rotation = car.transform.rotation;
        car.UnPark();
        ChangeTag("CarExit");
        GoToNextPosition();
    }

    public GemType WantedGem()
    {
        return chosenGem;
    }

    public Car GetCar()
    {
        return car;
    }

    public void GemDelivered()
    {
        GoToNextPosition();
        ChangeTag("ClientExit");
    }
}
