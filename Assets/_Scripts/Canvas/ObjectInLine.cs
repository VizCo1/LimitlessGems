using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using BreakInfinity;

public class ObjectInLine : MonoBehaviour
{
    [SerializeField] Button upgradeButton;
    [SerializeField] protected TMP_Text levelNumber;
    [SerializeField] protected TMP_Text costNumber;
    [SerializeField] protected int realMaxLevel = 10;
    [SerializeField] protected string levelCost = "100";
    [SerializeField] GameObject spacer;
    public int level { get; protected set; } = 1;

    [HideInInspector] public int index;
    [HideInInspector] public bool IsLevelMax  = false;

    // Start is called before the first frame update
    void Start()
    {
        costNumber.text = levelCost;
        levelNumber.text = level.ToString();
        levelCost = BigDouble.Parse(levelCost).ToString("G1");
        costNumber.text = levelCost;
    }

    public virtual void UpgradeButtonPressed()
    {
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
