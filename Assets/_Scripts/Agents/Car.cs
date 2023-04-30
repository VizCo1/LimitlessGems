using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    [SerializeField] Client client;

    bool imitateClient = true;
    [SerializeField] Material[] materials;
    [SerializeField] MeshRenderer meshRenderer;

    [HideInInspector] public bool parkUpwards;


    private void OnEnable()
    {
        //transform.position = client.transform.position;
        meshRenderer.material = materials[Random.Range(0, materials.Length)];
    }

    void Update()
    {
        if (imitateClient)
        {
            Vector3 pos = new Vector3(client.transform.localPosition.x, transform.localPosition.y, client.transform.localPosition.z);
            transform.SetLocalPositionAndRotation(client.transform.localPosition, client.transform.localRotation);
        }
    }

    public void Park()
    {
        imitateClient = false;
        if (parkUpwards)
            transform.DORotate(new Vector3(0, 90, 0), 0.5f);
        else
            transform.DORotate(new Vector3(0, -90, 0), 0.5f);
    }

    public void UnPark()
    {
        imitateClient = true;
    }


}
