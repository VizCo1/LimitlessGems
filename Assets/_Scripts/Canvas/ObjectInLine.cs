using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectInLine : MonoBehaviour
{
    [SerializeField] Button upgradeButton;
    [SerializeField] TMP_Text levelNumber;
    [SerializeField] int maxLevel = 100;
    int level = 1;

    [HideInInspector] public int index;
    
    // Start is called before the first frame update
    void Start()
    {
        levelNumber.text = level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeButton()
    {
        if (++level == maxLevel)
            upgradeButton.interactable = false;

        levelNumber.text = level.ToString();
    }
}
