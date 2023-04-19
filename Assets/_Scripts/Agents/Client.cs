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
        index = 0;
        transform.localPosition = Vector3.zero;
        GoToNextPosition();
        ChooseGem();
        ChangeTag("Car");
        meshRenderer.material = materials[Random.Range(0, materials.Length)];
    }

    private void Update()
    {
        if (b)
        {
            Debug.Log("INDEX: " + index);
        }
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

    public void GemReceived()
    {
        Debug.Log("Client recives the gem");
        GoToNextPosition();
        ChangeTag("ClientExit");
    }
}
