using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BreakInfinity;
using System;

public class GameController : MonoBehaviour
{
    Sequence spawnSequence;

    public static BigDouble money = new BigDouble(2000, 3);

    public static BigDouble gemPrice1 = new BigDouble(100);
    public static BigDouble gemPrice2 = new BigDouble(300);
    public static BigDouble gemPrice3 = new BigDouble(600);

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
                moneyToEarn = gemPrice1;
                break;
            case 1:
                moneyToEarn = gemPrice2;
                break;
            case 2:
                moneyToEarn = gemPrice3;
                break;
        }

        if (doubleMoney)
            moneyToEarn *= 2;

        money += moneyToEarn;

        CanvasManager.currentLayer.CheckButtons();
        CanvasManager.UpdateDisplayedMoney();
    }

    public static void IncreaseGemsPrices(float increase)
    {
        gemPrice1 *= increase;
        gemPrice2 *= increase;
        gemPrice3 *= increase;

        Debug.Log("GemPrice1: " + gemPrice1 + " GemPrice2: " + gemPrice2 + " GemPrice3: " + gemPrice3);
    }
}
