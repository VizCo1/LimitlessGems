using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : AgentBase
{

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
        chosenGem = Random.Range(0, 2);
    }

    public void AskForGem()
    {
        // Pedir gema a la zona de los trabajadores, una vez se ha creado la gema --> esperar a que se rellene el circulo del cliente.
        Debug.Log("Asking for gem");
    }

    void WaitInQueue()
    {
        // La zona Counter sabe cual es el counter m�s optimo por lo que se puede elegir directamente el counter al que ir.
        //agent.destination = counterZone.BestCounter();
    }

    /*
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(KEY_POSITION))
        {
            Debug.Log("Trigger");
            ZoneManager zone = other.GetComponent<ZoneManager>();
            // Pedirle al ZoneManager la zona del parking, counter, o rest zone a la que ir
            // Si est� todo lleno esperar hasta que haya hueco
            // Igual es mejor que la zona le proporcione la posici�n al jugador, podr�a tener una cola cada zona que representa cada cola
            GoToNextPosition();
        }
    }
    */
}
