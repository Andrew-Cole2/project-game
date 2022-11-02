using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text ClicksTotalText;
    public Button AutoClickerUpgrade;

    float TotalClicks;

    bool hasAutoClicker;

    public int clickValue;
    public int autoClicksPerSecond;
    public int minimumClicksToUnlock;


    public void AddClicks()
    {
        TotalClicks += clickValue;
        ClicksTotalText.text = TotalClicks.ToString("0");
    }

    public void AutoClickUpgrade()
    {
        if(!hasAutoClicker && TotalClicks >= minimumClicksToUnlock)
        {
            TotalClicks -= minimumClicksToUnlock;
            hasAutoClicker = true;
        }
    }

    public void UpgradeAutoClicker(int addClicks, Button btn)
    {
        if(hasAutoClicker)
        {
            autoClicksPerSecond += addClicks;
        }
    }

    public void UpgradeClick(int upgradeMultiplier)
    {
        clickValue *= upgradeMultiplier;
    }

    private void Start()
    {
        clickValue = 1;
        autoClicksPerSecond = 1;
    }

    private void Update()
    {
        if(hasAutoClicker)
        {
            TotalClicks += autoClicksPerSecond * Time.deltaTime;

            ClicksTotalText.text = TotalClicks.ToString("0");
        }

        if((!hasAutoClicker && TotalClicks <= minimumClicksToUnlock) || hasAutoClicker)
        {
            AutoClickerUpgrade.interactable = false;
        } 
        else if (!hasAutoClicker && TotalClicks >= minimumClicksToUnlock)
        {
            AutoClickerUpgrade.interactable = true;
        }
    }

}
