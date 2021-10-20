using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Image hpBar;
    private string hpBarTag = "HP Bar";

    void Awake()
    {
        hpBar = Helper.FindComponentInChildrenWithTag<Image>(gameObject, hpBarTag);
    }

    public void UpdateHpBar(float hpPercent)
    {
        hpBar.fillAmount = hpPercent;
    }
}
