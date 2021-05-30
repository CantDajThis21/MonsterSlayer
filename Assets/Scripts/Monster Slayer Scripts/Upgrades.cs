using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BreakInfinity;

public class Upgrades : MonoBehaviour
{   
    
    public GameController cont;
    public GameValues gamedata;
    public UpgradesUIManager clickupgrade;

    public BigDouble dps_upgrade_basecost;
    public BigDouble dps_upgrade_multcost;

    public BigDouble dps_basedmg;
    public BigDouble dps_dmgmultiplier;

    public string dmgdesc;
    
    // Start is called before the first frame update
    public void StartUpgrades()
    {
        gamedata = cont.gamedata;
        dps_upgrade_basecost = 7;
        dps_upgrade_multcost = 1.25;
        dps_basedmg = 3;
        UpdateUpgradePanelUI();
    }

    public BigDouble Cost(){
        return dps_upgrade_basecost * BigDouble.Ceiling(BigDouble.Pow(dps_upgrade_multcost, gamedata.dpsupgradelevel));
    }

    public void UpdateUpgradePanelUI(){
        clickupgrade.leveltxt.text ="Sword-" + gamedata.dpsupgradelevel.ToString();
        clickupgrade.costtxt.text = "$" + Cost().ToString("F2");
        clickupgrade.dmgtxt.text = "+" + gamedata.dps.ToString() + " Tap Damage";
    }
    
    public void BuyUpgrade(){

        if(gamedata.money >= Cost())
        {
            gamedata.money -= Cost();
            gamedata.dpsupgradelevel += 1;
            gamedata.tapdmg = BigDouble.Ceiling(BigDouble.Multiply(0.5, gamedata.dpsupgradelevel) * dps_basedmg);
            dps_basedmg += 0.25;
        }

        UpdateUpgradePanelUI();
    }
}
