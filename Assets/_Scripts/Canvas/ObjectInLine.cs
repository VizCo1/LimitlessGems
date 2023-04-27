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
    [SerializeField] int maxLevel = 100;
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
        if (!EnoughCost())
        {
            Debug.Log(BigDouble.Parse(costNumber.text));
            return;
        }

        GameController.money -= BigDouble.Parse(costNumber.text);

        costNumber.text = (BigDouble.Parse(costNumber.text) * 2).ToString();

        if (++level == maxLevel)
        {
            upgradeButton.interactable = false;
            IsLevelMax = true;
        }
        else if (EnoughCost())
        {
            upgradeButton.interactable = false;
        }

        levelNumber.text = level.ToString();

        UpdateAttributesAndCheckCosts();
    }

    protected virtual void UpdateAttributesAndCheckCosts()
    {

    }

    public bool EnoughCost()
    {
        return BigDouble.Parse(costNumber.text) <= GameController.money; 
    }

    public Button UpgradeButton()
    {
        return upgradeButton;
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
