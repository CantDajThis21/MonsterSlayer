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
    public TMP_Text timertxt;

    public double money;
    public double dps;
    public double health;
    public double healthcap{
        get{
            return 10 * System.Math.Pow(2, stage - 1) * isBoss;
        }
    }
    public float timer;


    public int stage;
    public int stagemax;
    public int kills;
    public int killsMax;
    public int isBoss;
    public int timermax;

    public GameObject back;
    public GameObject forward;

    public Image healthbar;
    public Image timerbar;

    public void Start()
    {
        dps = 1;
        stage = 1;
        stagemax = 1;
        killsMax = 10;
        health = 10;
        isBoss = 1;
        timermax = 30;
    }

    public void Update()
    {
        moneytxt.text = "Coins: " + money;
        stagetxt.text = "Stage - " + stage;
        killstxt.text = kills + "/" + killsMax;
        healthtxt.text = health + "/" + healthcap;
        dpstxt.text = "DPS: " + dps;
        timertxt.text = timer + "/" + timermax; 
        
        healthbar.fillAmount = (float)(health / healthcap);

        if (stage > 1) back.gameObject.SetActive(true);
        else 
            back.gameObject.SetActive(false);

        if (stage != stagemax) forward.gameObject.SetActive(true);
        else 
            forward.gameObject.SetActive(false);

    }


    public void IsBossChecker(){
                
        if(stage % 10 == 0){
            isBoss = 10;
            stagetxt.text = "Stage - " + stage + " (BOSS)!";
            timer -= Time.deltaTime;
            if(timer <= 0){
                stage -= 1;
                health = healthcap;
            }
            timertxt.text = timer + "/" + timermax;
            timerbar.gameObject.SetActive(true);
            timerbar.fillAmount = timer / timermax;   
        }
        else{
            isBoss = 1;
            stagetxt.text = "Stage - " + stage;
            timertxt.text = ""; 
            timerbar.gameObject.SetActive(false);
                }
    }

    public void Hit()
    {
        health -= dps;
        if(health <= 0)
        {
            money += System.Math.Ceiling(healthcap / 14) * stage;
            health = healthcap;
            if (stage == stagemax){
            kills += 1;
                if(kills >= killsMax){
                    kills = 0;
                    stage += 1;
                    stagemax += 1;
                }
            }
            IsBossChecker();
            health = healthcap;
            if(isBoss == 10){
                timer = timermax;
                killsMax = 10;
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
