using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BreakInfinity;
using System;

public class GameController : MonoBehaviour
{
    Sequence spawnSequence;

    public static BigDouble money = 100;

    [Header("Pool configuration")]

    [SerializeField] ObjectPool objectPool;
    [SerializeField] float spawnDelay;

    void Awake()
    {

        //money.
        //DOVirtual.DelayedCall(1, objectPool.SpawnPooledObject).SetLoops(5);
        CreateSpawnSequence(spawnDelay, -1);
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

    public static void EarnMoney(int gem)
    {
        switch (gem)
        {
            case 0:
                money += 0;
                break;
            case 1:
                money += 0;
                break;
            case 2:
                money += 0;
                break;
        }

        CanvasManager.UpdateMoney(money);
    }
}
