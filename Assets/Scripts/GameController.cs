using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BreakInfinity;


public class GameController : MonoBehaviour
{
    public GameValues gamedata;
    public Abbreviations ab;

    public TMP_Text moneytxt;
    public TMP_Text dpstxt;
    public TMP_Text stagetxt;
    public TMP_Text killstxt;
    public TMP_Text healthtxt;
    public TMP_Text timertext;

    public float StartTime = 30;

    public Image healthbar;
    public Image timericon;

    public void Start()
    {
        gamedata = new GameValues();
        ab = new Abbreviations();
        timertext.text = StartTime.ToString("0");
        timericon.gameObject.SetActive(false);
    }

    public void Update()
    {   
        
        moneytxt.text = "" + ab.Abbrevs(gamedata.money);
        stagetxt.text = "" + gamedata.stage;
        killstxt.text = gamedata.kills + "/" + gamedata.killsMax;
        healthtxt.text = ab.Abbrevs(gamedata.health) + "/" + ab.Abbrevs(gamedata.healthcap);
        dpstxt.text = "" + ab.Abbrevs(gamedata.dps);
        timericon.gameObject.SetActive(false);
        timertext.gameObject.SetActive(false);
        
        healthbar.fillAmount = (float)(gamedata.health / gamedata.healthcap);

       if(gamedata.stagemax % 10 == 0){
            if(gamedata.kills == 9){
                stagetxt.text = "BOSS!!";
            }
        }
 
        if (gamedata.stage % 10 == 0){
            if (gamedata.kills == 9){
                timericon.gameObject.SetActive(true);
                timertext.gameObject.SetActive(true);
                StartTime -= Time.deltaTime;
                timertext.text = StartTime.ToString("0");
            }
        }
        else{
            StartTime = 30;
        }
        if(StartTime < 0){
                    gamedata.stage = gamedata.stage - 1;
                }
    }

    public void IsBossChecker(){
        if(gamedata.stagemax % 10 == 0){
            if(gamedata.kills == 9){
                gamedata.isBoss = 10;
                gamedata.health = gamedata.healthcap;
            } 
        }
        else{
            gamedata.isBoss = 1;
            StartTime = 30;
            gamedata.health = gamedata.healthcap;
        }    
    }
    
    public void Hit()
    {
        gamedata.health -= gamedata.dps;
        if(gamedata.health <= 0)
        {
            gamedata.money += BigDouble.Multiply(BigDouble.Ceiling(BigDouble.Divide(gamedata.healthcap, 1000)), gamedata.kills + 1);
            if (gamedata.stage == gamedata.stagemax){
                 gamedata.kills += 1;
                if(gamedata.kills >= gamedata.killsMax){
                    gamedata.kills = 0;
                    gamedata.stagemax += 1;
                    gamedata.stage = gamedata.stagemax;
                }
            }
            IsBossChecker();
            gamedata.health = gamedata.healthcap;
            
        }
     }

}


