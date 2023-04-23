using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    Sequence spawnSequence;

    static int money;

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

    public static void EarnMoney(int gem)
    {
        switch (gem)
        {
            case 0:
                money += 1;
                break;
            case 1:
                money += 2;
                break;
            case 2:
                money += 3;
                break;
        }

        Canvas.UpdateMoneyText(money);
    }
}
