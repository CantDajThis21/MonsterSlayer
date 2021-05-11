using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GameValues
{

    public TMP_Text moneytxt;
    public TMP_Text dpstxt;
    public TMP_Text stagetxt;
    public TMP_Text killstxt;
    public TMP_Text healthtxt;

    public Image healthbar;

    public int stage;
    public int stagemax;
    public int kills;
    public int killsMax;
    public int isBoss;

    public double money;
    public double dps;
    public double health;
    public double healthcap{
        get{
            return 10 * System.Math.Pow(2, stage - 1) * isBoss;
        }
    }

    public GameValues(){
        dps = 1;
        stage = 1;
        stagemax = 1;
        killsMax = 10;
        health = 10;
        isBoss = 1; 
    }

}
