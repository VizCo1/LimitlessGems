using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Client : AgentBase
{
    [SerializeField] Car car;

    int chosenGem;

    void Start()
    {
        GoToNextPosition();
        ChooseGem();
    }

    void ChooseGem()
    {
        // TODO -> Change probabilities, GameManager will do it
        chosenGem = Random.Range(0, 2);
    }

    public int WantedGem()
    {
        return chosenGem;
    }

    public void ChangeTag(string t)
    {
        tag = t;
    }

    public Car GetCar()
    {
        return car;
    }

    public void GemReceived()
    {
        GoToNextPosition();
        ChangeTag("ClientExit");
        Debug.Log("Client receives gem");
    }
}
