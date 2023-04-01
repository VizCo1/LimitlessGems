using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Car : MonoBehaviour
{
    [SerializeField] Transform client;

    bool imitateClient = true;

    void Update()
    {
        if (imitateClient)
        {
            transform.SetPositionAndRotation(client.position, client.rotation);
        }
    }

    public void Park()
    {
        imitateClient = false;
        //transform.DO
    }
}
