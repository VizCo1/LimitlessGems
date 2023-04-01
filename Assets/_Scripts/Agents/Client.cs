using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Client : AgentBase
{
    [SerializeField] Car car;

    //[HideInInspector] public bool isParked = false;
    int chosenGem;
    
    void Start()
    {
        GoToNextPosition();
        ChooseGem();
    }

    void Update()
    {
        //Debug.Log(agent.destination);
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

    public void ParkCar()
    {
        car.Park();
    }

    public void ReceiveGem()
    {
        
    }
}
