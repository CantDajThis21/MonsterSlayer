using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text moneytxt;
    public TMP_Text dpstxt;
    public TMP_Text stagetxt;
    public TMP_Text killstxt;
    public TMP_Text healthtxt;

    public double money;
    public double dps;
    public double health;
    public double healthcap;
    public int stage;
    public int stagemax;
    public int kills;
    public int killsMax;
    public int isBoss;

    public GameObject back;
    public GameObject forward;

    public Image healthbar;

    public void Start()
    {
        dps = 1;
        stage = 1;
        stagemax = 1;
        killsMax = 10;
        healthcap = 10;
        health = healthcap;
        isBoss = 1;
    }

    public void Update()
    {
        moneytxt.text = "Coins: " + money;
        stagetxt.text = "Stage - " + stage;
        killstxt.text = kills + "/" + killsMax;
        healthtxt.text = health + "/" + healthcap;
        dpstxt.text = "DPS: " + dps;
        
        healthbar.fillAmount = (float)(health / healthcap);

        if (stage > 1) back.gameObject.SetActive(true);
        else 
            back.gameObject.SetActive(false);

        if (stage != stagemax) forward.gameObject.SetActive(true);
        else 
            forward.gameObject.SetActive(false);
        healthcap = 10 * System.Math.Pow(2, stage - 1) * isBoss;
        
            if(stage % 10 == 0){
                isBoss = 10;
                stagetxt.text = "Stage - " + stage + "(BOSS)!";
        }
        else{
            isBoss = 1;
        }
    }

    public void Hit()
    {
        health -= dps;
        if(health <= 0)
        {
            money += System.Math.Ceiling(healthcap / 14);
            health = healthcap;
            if (stage == stagemax){
            kills += 1;
                if(kills >= killsMax){
                    kills = 0;
                    stage += 1;
                    stagemax += 1;
                }
            }
        }
    }
    public void Back()
    {
        if (stage > 1){
            kills = 0;
            stage -=1;
            killstxt.text = kills + "/" + killsMax;
            healthtxt.text = health + "/" + healthcap; 
        }
    }

    public void Forward()
    {
        if (stage != stagemax){
            stage +=1;
        }
    }

}
