using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BreakInfinity;
using System;

public class GameController : MonoBehaviour
{
    Sequence spawnSequence;

    public static BigDouble money = new BigDouble(2, 1000);

    [Header("Pool configuration")]

    [SerializeField] ObjectPool objectPool;
    [SerializeField] float spawnDelay;

    void Awake()
    {
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

    public static void SellGem(int gem, bool doubleMoney)
    {
        BigDouble moneyToEarn = new();
        switch (gem)
        {
            case 0:
                moneyToEarn = 5000;
                break;
            case 1:
                moneyToEarn = 10000;
                break;
            case 2:
                moneyToEarn = 30000;
                break;
        }

        if (doubleMoney)
            moneyToEarn *= 2;

        money += moneyToEarn;

        CanvasManager.currentLayer.CheckButtons();
        CanvasManager.UpdateDisplayedMoney();
    }
}
