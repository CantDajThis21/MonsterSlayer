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
    public TMP_Text timertext;

    public float StartTime = 30;

    public double money;
    public double dps;
    public double health;
    public double healthcap{
        get{
            return 10 * System.Math.Pow(2, stage - 1) * isBoss;
        }
    }

    public int stage;
    public int stagemax;
    public int kills;
    public int killsMax;
    public int isBoss;

    public GameObject back;
    public GameObject forward;

    public Image healthbar;
    public Image timericon;

    public void Start()
    {
        dps = 1;
        stage = 1;
        stagemax = 1;
        killsMax = 10;
        health = 10;
        isBoss = 1; 
        timertext.text = StartTime.ToString("0");
        timericon.gameObject.SetActive(false);
    }

    public void Update()
    {
        moneytxt.text = "" + money;
        stagetxt.text = "" + stage;
        killstxt.text = kills + "/" + killsMax;
        healthtxt.text = health + "/" + healthcap;
        dpstxt.text = "" + dps;
        timericon.gameObject.SetActive(false);
        timertext.gameObject.SetActive(false);
        
        healthbar.fillAmount = (float)(health / healthcap);

        if (stage != stagemax){ 
            forward.gameObject.SetActive(true);
        }
        else 
            forward.gameObject.SetActive(false);

        if (stage > 1) {
            back.gameObject.SetActive(true);
            }
        else 
            back.gameObject.SetActive(false);
       
        if (stage == 10){
            if (kills == 9){
                timericon.gameObject.SetActive(true);
                timertext.gameObject.SetActive(true);
                StartTime -= Time.deltaTime;
                timertext.text = StartTime.ToString("0");
            }
        }

    }


    public void IsBossChecker(){
        if(stagemax % 10 == 0){
            BossHealth();
        }
        else{
            isBoss = 1;
        }    
    }


    public void BossHealth(){
        if (stage == 10){
            if (kills == 9){
                isBoss = 10;
                health = healthcap;
                stagetxt.text = "Stage" + stage;
                StartTime -= Time.deltaTime;
                timericon.gameObject.SetActive(true);
                timertext.text = StartTime.ToString("0");
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
            money += System.Math.Ceiling((healthcap / 20) * stage - stage/healthcap);
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
            stage -= 1;
            killstxt.text = kills + "/" + killsMax;
            healthtxt.text = health + "/" + healthcap; 
            kills = 0;
        }
        if (stage == 10){
            if (kills == 9){
                isBoss = 10;
                health = healthcap;
                stagetxt.text = "Stage" + stage;
                timericon.gameObject.SetActive(true);
                timertext.gameObject.SetActive(true);
                StartTime -= Time.deltaTime;
                timertext.text = StartTime.ToString("0");
            }
            else{
                isBoss = 1;
            }
        }
    }

    public void Forward()
    {
        if (stage != stagemax){
            stage +=1;
            kills = 0;
        }
        if (stage == 10){
            if (kills == 9){
                isBoss = 10;
                health = healthcap;
                stagetxt.text = "Stage" + stage;
                timericon.gameObject.SetActive(true);
                timertext.gameObject.SetActive(true);
                StartTime -= Time.deltaTime;
                timertext.text = StartTime.ToString("0");
            }
            else{
                isBoss = 1;
            }
        }
    }

}


