using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    [SerializeField] Transform client;

    bool imitateClient = true;
    [SerializeField] Material[] materials;
    [SerializeField] MeshRenderer meshRenderer;

    [HideInInspector] public bool parkUpwards;

    public Vector3 targetPosition { get; private set; }


    private void OnEnable()
    {
        //transform.position = client.transform.position;
        meshRenderer.material = materials[Random.Range(0, materials.Length)];
    }

    void Update()
    {
        if (imitateClient)
        {
            //Vector3 pos = new Vector3(client.localPosition.x, transform.localPosition.y, client.localPosition.z);
            transform.SetLocalPositionAndRotation(client.localPosition, client.localRotation);
        }
    }

    public void Park(Vector3 desiredPos)
    {
        imitateClient = false;
        if (parkUpwards)
            transform.DORotate(new Vector3(0, 90, 0), 0.5f);
        else
            transform.DORotate(new Vector3(0, -90, 0), 0.5f);

        if (desiredPos == Vector3.zero)
        {
            targetPosition = transform.position;
        }
        else
        {
            targetPosition = desiredPos;
        }
    }

    public void UnPark()
    {
        imitateClient = true;
    }


}
