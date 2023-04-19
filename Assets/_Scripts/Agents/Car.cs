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
            Vector3 pos = new Vector3(client.transform.localPosition.x, transform.localPosition.y, client.transform.localPosition.z);
            transform.SetLocalPositionAndRotation(pos, client.transform.localRotation);
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
