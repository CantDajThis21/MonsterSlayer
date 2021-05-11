using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameValues gamedata;
    public TimerScript timedata;

    public GameObject back;
    public GameObject forward;

    public void Start()
    {
        gamedata = new GameValues();
        timedata = new TimerScript();
        
    }

    public void Update()
    {
        gamedata.moneytxt.text = "" + gamedata.money;
        gamedata.stagetxt.text = "" + gamedata.stage;
        gamedata.killstxt.text = gamedata.kills + "/" + gamedata.killsMax;
        gamedata.healthtxt.text = gamedata.health + "/" + gamedata.healthcap;
        gamedata.dpstxt.text = "" + gamedata.dps;
        timedata.timericon.gameObject.SetActive(false);
        timedata.timertext.gameObject.SetActive(false);
        
        gamedata.healthbar.fillAmount = (float)(gamedata.health / gamedata.healthcap);

        if(gamedata.stagemax % 10 == 0){
            if(gamedata.kills == 9){
                gamedata.stagetxt.text = "BOSS!!";
            }
        }

        if (gamedata.stage != gamedata.stagemax){ 
            forward.gameObject.SetActive(true);
        }
        else 
            forward.gameObject.SetActive(false);

        if (gamedata.stage > 1) {
            back.gameObject.SetActive(true);
            }
        else 
            back.gameObject.SetActive(false);
 
        if (gamedata.stage % 10 == 0){
            if (gamedata.kills == 9){
                timedata.timericon.gameObject.SetActive(true);
                timedata.timertext.gameObject.SetActive(true);
                timedata.StartTime -= Time.deltaTime;
                timedata.timertext.text = timedata.StartTime.ToString("0");
            }
        }
        else{
            timedata.StartTime = 30;
        }
        if(timedata.StartTime < 0){
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
            timedata.StartTime = 30;
            gamedata.health = gamedata.healthcap;
        }    
    }
    
    public void Hit()
    {
        gamedata.health -= gamedata.dps;
        if(gamedata.health <= 0)
        {
            gamedata.money += System.Math.Ceiling((gamedata.healthcap / 1000) * gamedata.kills + 1);
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
    public void Back()
    {
        if (gamedata.stage == 10){
            if (gamedata.kills == 9){
                gamedata.isBoss = 10;
                gamedata.health = gamedata.healthcap;
                gamedata.stagetxt.text = "Stage" + gamedata.stage;
                timedata.timericon.gameObject.SetActive(true);
                timedata.timertext.gameObject.SetActive(true);
                timedata.StartTime -= Time.deltaTime;
                timedata.timertext.text = timedata.StartTime.ToString("0");
            }
            else{
                gamedata.isBoss = 1;
            }
        }
        gamedata.health = gamedata.healthcap;
        gamedata.stage -= 1;
    }

    public void Forward()
    {
        if (gamedata.stage == 10){
            if (gamedata.kills == 9){
                gamedata.isBoss = 10;
                gamedata.health = gamedata.healthcap;
                gamedata.stagetxt.text = "Stage" + gamedata.stage;
                timedata.timericon.gameObject.SetActive(true);
                timedata.timertext.gameObject.SetActive(true);
                timedata.StartTime -= Time.deltaTime;
                timedata.timertext.text = timedata.StartTime.ToString("0");
            }
            else{
                gamedata.isBoss = 1;
            }
        }
        gamedata.health = gamedata.healthcap;
        gamedata.stage += 1;
    }

}


