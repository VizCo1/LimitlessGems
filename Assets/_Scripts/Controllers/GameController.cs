using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BreakInfinity;
using System;

public class GameController : MonoBehaviour
{

    public static BigDouble money = new BigDouble(5000, 0);

    public static BigDouble gemPrice1 = new BigDouble(100);
    public static BigDouble gemPrice2 = new BigDouble(300);
    public static BigDouble gemPrice3 = new BigDouble(600);

    public static int[] gemsQuantity = new int[3] { 0, 0, 0 };

    static float spawnDelay = 60; // 60 --> 1 client per min
    static ObjectPool objectPool;
    static Sequence spawnSequence;

    void Awake()
    {
        //DOVirtual.DelayedCall(1, objectPool.SpawnPooledObject).SetLoops(5);
        objectPool = transform.parent.GetComponentInChildren<ObjectPool>();
        CreateSpawnSequence(20, 1);
        //CreateSpawnSequence(-1);
    }

    public void ClientOut(GameObject client)
    {
        objectPool.ReturnPooledObject(client);
    }

    public void CreateSpawnSequence(int loops, float delay)
    {
        spawnSequence.Kill();
        spawnSequence = DOTween.Sequence().SetDelay(delay)
            .AppendCallback(objectPool.SpawnPooledObject)
            .SetLoops(loops)
            .OnKill(() => CreateSpawnSequence(-1));
    }

    public static void CreateSpawnSequence(int loops)
    {
        spawnDelay *= 0.75f;
        Debug.Log("Spawn delay: " + spawnDelay);
        spawnSequence.Kill();
        spawnSequence = DOTween.Sequence().SetDelay(spawnDelay)
            .AppendCallback(objectPool.SpawnPooledObject)
            .SetLoops(loops);
    }

    public static void UpdateGemQuantity(int gem, int quantity)
    {
        int gemToChange = -1;

        switch (gem)
        {
            case 0:
                gemToChange = 0;
                gemsQuantity[0] += quantity;

                break;
            case 1:
                gemToChange = 1;
                gemsQuantity[1] += quantity;
                break;
            case 2:
                gemToChange = 2;
                gemsQuantity[2] += quantity;
                break;
        }

        if (gemToChange != -1)
        {
            //Debug.Log(gemsQuantity[gemToChange]);

            CanvasManager.UpdateDisplayedGems(gemToChange, gemsQuantity[gemToChange]);
        }
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

        if (CanvasManager.currentLayer != null)
            CanvasManager.currentLayer.CheckButtons();
        CanvasManager.UpdateDisplayedMoney();
    }

    public static void IncreaseGemsPrices(float increase)
    {
        gemPrice1 *= increase;
        gemPrice2 *= increase;
        gemPrice3 *= increase;

        //Debug.Log("GemPrice1: " + gemPrice1 + " GemPrice2: " + gemPrice2 + " GemPrice3: " + gemPrice3);
    }
}
