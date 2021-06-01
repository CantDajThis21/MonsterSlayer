using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using BreakInfinity;


public class GameController : MonoBehaviour
{

    public Upgrades upgrades;
    public GameValues gamedata;
    public Abbreviations ab;
    public ObjectPooler objpool;
    public PlayFabManager playfab;

    public TMP_Text moneytxt;
    public TMP_Text dpstxt;
    public TMP_Text stagetxt;
    public TMP_Text killstxt;
    public TMP_Text healthtxt;
    public TMP_Text timertext;

    public float timer;
    public int stage;

    public Image healthbar;
    public Image timericon;

    public void Start()
    {
        // playfab = new PlayFabManager();
        gamedata = new GameValues();
        ab = new Abbreviations();
        timertext.text = timer.ToString("0");
        timericon.gameObject.SetActive(false);
        upgrades.StartUpgrades();
    }

    public void Update()
    {   
        stage = gamedata.stage;
        moneytxt.text = "" + " " + ab.Abbrevs(gamedata.money);
        stagetxt.text = "" + gamedata.stage;
        killstxt.text = gamedata.kills + "/" + gamedata.killsMax;
        healthtxt.text = ab.Abbrevs(gamedata.health) + "/" + ab.Abbrevs(gamedata.healthcap);
        dpstxt.text = "" + " " + ab.Abbrevs(gamedata.dps);
        timericon.gameObject.SetActive(false);
        timertext.gameObject.SetActive(false);
        
        healthbar.fillAmount = (float)(gamedata.health / gamedata.healthcap);

        if(gamedata.stagemax % 10 == 0){
            if(gamedata.kills == 9){
                stagetxt.text = "BOSS!!";
            }
        }

        if(gamedata.healthcap == 0){

        }

        if (gamedata.stage % 10 == 0){
            if (gamedata.kills == 9){
                timericon.gameObject.SetActive(true);
                timertext.gameObject.SetActive(true);
                timertext.text = "" + timer;
                if(timer == 0){
                    gamedata.kills = 0;
                    gamedata.stage = gamedata.stage - 1;
                    gamedata.stagemax = gamedata.stagemax - 1;
                    stagetxt.text = "" + gamedata.stage;
                    killstxt.text = "" + gamedata.kills;
                    timericon.gameObject.SetActive(false);
                    timericon.gameObject.SetActive(false);
                }
            }
        }
        else{
            timer = 30;
        }
    }

    public IEnumerator StartCountdown(float cdval = 30){
        timer = cdval;
        while (timer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timer--;
        }
    }

    public void IsBossChecker(){
        if(gamedata.stagemax % 10 == 0){
            if(gamedata.kills == 9){
                StartCoroutine(StartCountdown());
                gamedata.isBoss = 10;
                gamedata.health = gamedata.healthcap;
            } 
        }
        else{
            gamedata.isBoss = 1;
            timer = 30;
            gamedata.health = gamedata.healthcap;
        }    
    }
    
    public void Hit()
    {
        gamedata.health -= gamedata.dps;
        if(gamedata.health <= 0)
        {
            gamedata.money += BigDouble.Multiply(BigDouble.Ceiling(BigDouble.Divide(gamedata.healthcap, 100)), gamedata.kills + 3);
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
    public void LeaderBoardButton() {
        playfab.SendLeaderboard(gamedata.stage);
    }
}


