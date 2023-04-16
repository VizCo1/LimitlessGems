using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Client : AgentBase
{
    [SerializeField] Car car;

    int chosenGem;

    private void OnEnable()
    {
        index = 0;
        GoToNextPosition();
        ChooseGem();
        ChangeTag("Car");
    }

    void ChooseGem()
    {
        // TODO -> Change probabilities, GameManager will do it
        //chosenGem = Random.Range(0, 3);
        chosenGem = 0;
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

    public int WantedGem()
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
