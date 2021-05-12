using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BreakInfinity;

public class GameValues {

    public BigDouble money;
    public BigDouble dps;
    public BigDouble health;
    public BigDouble healthcap{
        get{
            return 10 * System.Math.Pow(2, stage - 1) * isBoss;
        }
    }

    public int stage;
    public int stagemax;
    public int kills;
    public int killsMax;
    public int isBoss;

public GameValues(){
        dps = 1.5e10;
        stage = 1;
        stagemax = 1;
        killsMax = 10;
        health = 10;
        isBoss = 1;
}

}
