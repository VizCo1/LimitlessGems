using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using BreakInfinity;
using DG.Tweening;

public class ObjectInLine : MonoBehaviour
{
    [SerializeField] Button upgradeButton;
    [SerializeField] TMP_Text levelNumber;
    [SerializeField] TMP_Text costNumber;
    [SerializeField] int maxLevel = 100;
    [SerializeField] string levelCost = "100";
    int level = 1;

    Tween checkEnoughMoneyTween;

    [HideInInspector] public int index;
    
    // Start is called before the first frame update
    void Start()
    {
        costNumber.text = levelCost;
        levelNumber.text = level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeButtonPressed()
    {
        if (GameController.money < BigDouble.Parse(costNumber.text))
        {
            Debug.Log(BigDouble.Parse(costNumber.text));
            return;
        }

        GameController.money -= BigDouble.Parse(costNumber.text);

        costNumber.text = (BigDouble.Parse(costNumber.text) * 2).ToString();

        if (++level == maxLevel)
            upgradeButton.interactable = false;
        else if (BigDouble.Parse(costNumber.text) > GameController.money)
        {
            upgradeButton.interactable = false;
            checkEnoughMoneyTween = DOVirtual.DelayedCall(0.75f, () => 
            { 
                if (GameController.money > BigDouble.Parse(costNumber.text))
                {
                    upgradeButton.interactable = true;

                }
            }).SetLoops(-1);
        }


        levelNumber.text = level.ToString();

        CounterLayer.UpdateCounterAttributes(index);
    }
}
