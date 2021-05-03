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
    public GameObject timericon;

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
        timer = 30;
        timermax = 30;
        timericon.gameObject.SetActive(false);

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

        if (stage != stagemax){ 
            kills = 0;
            forward.gameObject.SetActive(true);
            health = healthcap;
            stagemax = stage;
        }
        else 
            forward.gameObject.SetActive(false);

        if (stage > 1) {
            back.gameObject.SetActive(true);
            health = healthcap;
            stagemax = stage;
            }
        else 
            back.gameObject.SetActive(false);
            

        
        
    }


    public void IsBossChecker(){
        if(stagemax % 10 == 0){
            
            BossHealth();

            // while (timer > 0)
            // {
            //     //StartCoroutine(A_routine());
            //     
            // }
            // Debug.Log(timer);
            

            if(timer <= 0){
                stage -= 1;
                health = healthcap;
            }
               
        }
        else{
            isBoss = 1;
            stagetxt.text = "Stage - " + stage;
            timertxt.text = ""; 
            timerbar.gameObject.SetActive(false);
            Debug.Log(timer);
                }            
    }

    IEnumerator A_routine(){
        yield return new WaitForSeconds(0.5f);
        timer -= 1;
        Debug.Log(timer);
    }

    public void BossHealth(){
        if (stage == 10){
            if (kills == 9){
                isBoss = 10;
                health = healthcap;
                timericon.gameObject.SetActive(true);
                timer = timermax;
                timertxt.text = timer + "/" + timermax;
                timerbar.gameObject.SetActive(true);
                timerbar.fillAmount = timer / timermax;
                stagetxt.text = "Stage - " + stage + " (BOSS)!";
            }
        }
    }
    public void OnMouseDown(){
        Hit();
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
                    stagemax += 1;
                    stage = stagemax;
                }
            }
            IsBossChecker();
            
        }
    }
    public void Back()
    {
        if (stage > 1){
            kills = 0;
            stage -= 1;
            killstxt.text = kills + "/" + killsMax;
            healthtxt.text = health + "/" + healthcap; 
        }
    }

    public void Forward()
    {
        if (stage != stagemax){
            stage +=1;
            kills = 0;
        }
    }

}


