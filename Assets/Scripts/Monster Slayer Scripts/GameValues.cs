using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BreakInfinity;

public class GameValues {

    public BigDouble money;
    public BigDouble dps{
        get{
            return tapdmg;
        }
    }
    public BigDouble health;
    public BigDouble healthcap{
        get{
            return 5 * System.Math.Pow(1.5, stage - 1) * isBoss;
        }
    }
    public BigDouble dpsupgradelevel;
    public BigDouble tapdmg;

    public int stage;
    public int stagemax;
    public int kills;
    public int killsMax;
    public int isBoss;

public GameValues(){
        dpsupgradelevel = 1;
        tapdmg = 1;
        stage = 1;
        stagemax = 1;
        killsMax = 10;
        health = 5;
        isBoss = 1;
}

}
