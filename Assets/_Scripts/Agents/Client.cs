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

    GemType chosenGem;

    private void OnEnable()
    {
        index = 0;
        transform.localPosition = Vector3.zero;
        GoToNextPosition();
        ChooseGem();
        ChangeTag("Car");
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

    void ChangeTag(string t)
    {
        tag = t;
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
