using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    ObjectPool objectPool;
    Tween spawnTween;

    void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
        //DOVirtual.DelayedCall(1, objectPool.SpawnPooledObject).SetLoops(5);
        CreateSpawnTween(4, -1);
    }

    public void ClientOut(GameObject client)
    {
        objectPool.ReturnPooledObject(client);
    }

    void CreateSpawnTween(float delay, int loops)
    {
        spawnTween.Kill();
        spawnTween = DOVirtual.DelayedCall(delay, objectPool.SpawnPooledObject).SetLoops(loops);
    }
}
