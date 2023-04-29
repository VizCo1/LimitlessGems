using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using BreakInfinity;

public class ObjectInLine : MonoBehaviour
{
    [SerializeField] Button upgradeButton;
    [SerializeField] TMP_Text levelNumber;
    [SerializeField] TMP_Text costNumber;
    [SerializeField] int maxLevel = 10;
    [SerializeField] string levelCost = "100";
    [SerializeField] GameObject spacer;
    int level = 1;

    [HideInInspector] public int index;
    public bool IsLevelMax { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        costNumber.text = levelCost;
        levelNumber.text = level.ToString();
    }

    public void UpgradeButtonPressed()
    {
        if (!CanvasManager.EnoughCost(levelCost))
        {
            return;
        }

        GameController.money -= BigDouble.Parse(levelCost);

        levelCost = (BigDouble.Parse(costNumber.text) * 2).ToString();
        costNumber.text = levelCost;

        if (++level == maxLevel)
        {
            IsLevelMax = true;
            levelCost = "FULL";
            costNumber.text = levelCost;
        }

        levelNumber.text = level.ToString();
        
        UpdateAttributesAndCheckCosts();
    }

    protected virtual void UpdateAttributesAndCheckCosts()
    {

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
