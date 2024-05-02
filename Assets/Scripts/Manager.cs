using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI ClicksTotalText;

    float TotalClicks;

    bool hasUpgrade;

    public int autoClicksPerSecond;
    public int minimumClicksToUnlockUpgrade;

    private float autoClickDelay;
    public void AddClicks()
    {
        TotalClicks++ ;
        ClicksTotalText.text = TotalClicks.ToString("0");
    }

    public void AutoClickUpgrade()
    {
        if(!hasUpgrade && TotalClicks >= minimumClicksToUnlockUpgrade)
        {
            TotalClicks -= minimumClicksToUnlockUpgrade;
            hasUpgrade = true;
        }
    }

    private void Update()
    {
        if(hasUpgrade)
        {
            autoClickDelay -= Time.deltaTime;
            if(autoClickDelay <= 0) 
            {
                TotalClicks +=1;
                autoClickDelay = 1;

                ClicksTotalText.text = TotalClicks.ToString("0");
            }
            
        }
    }
}
