using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    ObjectPool objectPool;
    Sequence spawnSequence;

    [SerializeField] float delay;

    void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
        //DOVirtual.DelayedCall(1, objectPool.SpawnPooledObject).SetLoops(5);
        CreateSpawnSequence(delay, -1); // QUE PASA CON ESTO: Pues que cuando el coche va a entrar al parking justo antes de hacer Dequeue se llama a esto mmm
    }

    public void ClientOut(GameObject client)
    {
        objectPool.ReturnPooledObject(client);
    }

    void CreateSpawnSequence(float delay, int loops)
    {
        spawnSequence.Kill();
        spawnSequence = DOTween.Sequence().SetDelay(delay)
            .AppendCallback(objectPool.SpawnPooledObject)
            .SetLoops(loops);
    }
}
