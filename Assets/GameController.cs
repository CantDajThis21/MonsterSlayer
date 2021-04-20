using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public double money;
    public double dps;
    public double health;
    public double healthcap;
    public int stage;
    public int stagemax;
    public int kills;
    public int killsMax;

    //public TextMeshProUGUI moneytxt;
    public Text moneytxt;
    public TextMeshProUGUI dpstxt;
    public TextMeshProUGUI stagetxt;
    public TextMeshProUGUI killstxt;
    public TextMeshProUGUI healthtxt;

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
        //moneytxt = GetComponent<TextMeshProUGUI>();
    }

    public void update()
    {
        moneytxt.text = money.ToString("F2");
        dpstxt.text = dps + "Damage Per Second";
        stagetxt.text = "Stage - " + stage;
        killstxt.text = kills + "/" + killsMax;
        healthtxt.text = health + "/" + healthcap + "HP";
        
        healthbar.fillAmount = (float)(health / healthcap);

        if (stage > 1) back.gameObject.SetActive(true);
        else 
            back.gameObject.SetActive(false);

        if (stage != stagemax) forward.gameObject.SetActive(true);
        else 
            forward.gameObject.SetActive(false);
    }

    public void Hit()
    {
        health -= dps;
        if(health <= 0){
            money += 1;
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
            stage -=1;
        }
    }

    public void Forward()
    {
        if (stage != stagemax){
            stage +=1;
        }
    }


}
