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

    public int autoClicksPerSecond;
    public int minimumClicksToUnlock;

    public void AutoClickUpgrade()
    {
        if(!hasAutoClicker && TotalClicks >= minimumClicksToUnlock)
        {
            TotalClicks -= minimumClicksToUnlock;
            hasAutoClicker = true;
        }
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

    public  void AddClicks()
    {
        TotalClicks++;
        ClicksTotalText.text = TotalClicks.ToString("0");
    }

}
