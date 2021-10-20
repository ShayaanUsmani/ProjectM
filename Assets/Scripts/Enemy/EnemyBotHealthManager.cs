using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBotHealthManager : MonoBehaviour
{
    [SerializeField]
    private int maxHp;
    [SerializeField]
    private HPBar hpBar;

    private string HpBarCanvasTag = "Stat UI";


    private int hp;
    private float hpPercent; // might use later for percent damage or execute abilities
  
    void Start()
    {
        if (maxHp == 0)
        {
            maxHp = 750;
        }
        hp = maxHp;
        hpPercent = 1;

        if (hpBar == null)
        {
            Canvas hpBarCanvas = Helper.FindComponentInChildrenWithTag<Canvas>(gameObject, HpBarCanvasTag);
            hpBar = hpBarCanvas.GetComponent(typeof(HPBar)) as HPBar;
        }
    }

    public void takeDamage(int dmg)
    {
        int newHp = hp - dmg;
        if (newHp >= 10)
        {
            hp = newHp;
            float hpPercent = (float)hp / (float)maxHp;
            
            hpBar.UpdateHpBar(hpPercent);
        }

    }




}
