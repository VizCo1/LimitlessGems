using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Car : MonoBehaviour
{
    [SerializeField] Client client;

    bool imitateClient = true;

    private void OnEnable()
    {
        transform.localPosition = Vector3.zero;
    }

    void Update()
    {
        if (imitateClient)
        {
            transform.SetPositionAndRotation(client.transform.position, client.transform.rotation);
        }
    }

    public void Park()
    {
        imitateClient = false;
    }

    public void UnPark()
    {
        imitateClient = true;
    }
}
