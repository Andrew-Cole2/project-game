using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBtn {
    public Button button;
    public int value;
    public int cost;

    public UpgradeBtn(Button newButton, int newValue, int newCost) { 
        button = newButton;
        value = newValue;
        cost = newCost;
    }
}


public class Manager : MonoBehaviour
{
    public Text ClicksTotalText;
    public Button AutoClickerUpgrade;
    public Button AutoUpgrade_10;
    public Button AutoUpgrade_100;
    public Button AutoUpgrade_1000;
    public Button ClickUpgrade_2;
    public Button ClickUpgrade_5;
    public Button ClickUpgrade_10;

    public UpgradeBtn[] upgradeButtons = new UpgradeBtn[6];


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

    public void BuyAutoClicker()
    {
        if ((!hasAutoClicker && TotalClicks >= minimumClicksToUnlock))
        {
            TotalClicks -= minimumClicksToUnlock;
            hasAutoClicker = true;
        }
    }

    public void BuildBtnArray() {
        upgradeButtons[0] = new UpgradeBtn(AutoUpgrade_10, 10, 100);
        upgradeButtons[1] = new UpgradeBtn(AutoUpgrade_100, 100, 1000);
        upgradeButtons[2] = new UpgradeBtn(AutoUpgrade_1000, 1000, 10000);
        upgradeButtons[2] = new UpgradeBtn(ClickUpgrade_2, 2, 1000);
        upgradeButtons[2] = new UpgradeBtn(ClickUpgrade_5, 5, 10000);
        upgradeButtons[2] = new UpgradeBtn(ClickUpgrade_10, 10, 100000);
    }

    private void Start()
    {
        BuildBtnArray();

        AutoUpgrade_10.onClick.AddListener(() => UpgradeAutoClick(upgradeButtons[0].value, upgradeButtons[0].cost));
        AutoUpgrade_100.onClick.AddListener(() => UpgradeAutoClick(upgradeButtons[1].value, upgradeButtons[1].cost));
        AutoUpgrade_100.onClick.AddListener(() => UpgradeAutoClick(upgradeButtons[2].value, upgradeButtons[2].cost));
        ClickUpgrade_2.onClick.AddListener(() => UpgradeClick(upgradeButtons[3].value, upgradeButtons[3].cost));
        ClickUpgrade_5.onClick.AddListener(() => UpgradeClick(upgradeButtons[4].value, upgradeButtons[4].cost));
        ClickUpgrade_10.onClick.AddListener(() => UpgradeClick(upgradeButtons[5].value, upgradeButtons[5].cost));
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

    public void UpgradeAutoClick(int upgradeAmount, int cost)
    {
        if (hasAutoClicker && TotalClicks >= cost)
        {
            TotalClicks -= cost;
            autoClicksPerSecond += upgradeAmount;
        }
    }

    public void UpgradeClick(int upgradeMultiplier, int cost)
    {
        if (hasAutoClicker && TotalClicks >= cost)
        {
            TotalClicks -= cost;
            clickValue *= upgradeMultiplier;
        }
    }

}
