using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using BreakInfinity;
using ZSerializer;

public class ObjectInLine : PersistentMonoBehaviour
{
    [NonZSerialized][SerializeField] Button upgradeButton; // no
    [NonZSerialized][SerializeField] protected TMP_Text costNumber; // no
    [NonZSerialized][SerializeField] protected int realMaxLevel = 10; // no
    [NonZSerialized][SerializeField] GameObject spacer; // no

    [SerializeField] protected TMP_Text levelNumber; // no
    [HideInInspector][SerializeField] public string levelCost = "100"; // save
    [HideInInspector] public int level  = 1; // save

    [NonZSerialized][HideInInspector] public int index;
    [HideInInspector] public bool IsLevelMax  = false; // save

    // Start is called before the first frame update
    void Start()
    {
        levelNumber.text = level.ToString();
        if (levelCost != "FULL")
            levelCost = BigDouble.Parse(levelCost).ToString("G1");
        costNumber.text = levelCost;
    }

    public virtual void UpgradeButtonPressed()
    {
        for (int i = 0; i < 20; i++)    // I KNOW IT'S BAD
        {
            // I KNOW IT'S BAD
            if (IsTargetLevelReached())
                return;

            if (!IsLevelMax && !CanvasManager.EnoughCost(levelCost))
            {
                return;
            }           

            GameController.money -= BigDouble.Parse(levelCost);

            level++;

            if (level == realMaxLevel)
            {
                IsLevelMax = true;
                levelCost = "FULL";
                costNumber.text = levelCost;
            }
            else if (IsTargetLevelReached())
            {
                IsLevelMax = true;
            }
            else
            {
                levelCost = (BigDouble.Parse(costNumber.text) * 1.5f).ToString("G1");
                costNumber.text = levelCost;
            }

            levelNumber.text = level.ToString();

            UpdateAttributesAndCheckCosts();
        }
    }

    /*public virtual void UpgradeButtonPressed()
    {
        if (!CanvasManager.EnoughCost(levelCost))
        {
            return;
        }

        GameController.money -= BigDouble.Parse(levelCost);

        if (++level == realMaxLevel)
        {
            IsLevelMax = true;
            levelCost = "FULL";
            costNumber.text = levelCost;
        }
        else
        {
            levelCost = (BigDouble.Parse(costNumber.text) * 1.5f).ToString("G1");
            costNumber.text = levelCost;
        }

        levelNumber.text = level.ToString();
        
        UpdateAttributesAndCheckCosts();
    }*/

    protected virtual void UpdateAttributesAndCheckCosts()
    {

    }

    protected virtual bool IsTargetLevelReached()
    {
        Debug.Log("NO");
        return false;
    }

    public Button UpgradeButton()
    {
        return upgradeButton;
    }

    public string LevelCost()
    {
        return levelCost;
    }

    private void OnEnable()
    {
        spacer.SetActive(true);
    }

    private void OnDisable()
    {
        spacer.SetActive(false);
    }
}
