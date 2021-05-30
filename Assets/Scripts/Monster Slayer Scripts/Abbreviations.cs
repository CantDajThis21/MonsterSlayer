using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BreakInfinity;

public class Abbreviations{

    public string Abbrevs(BigDouble num)
    {
        string result;
        string[] Abbrevs = new string[] {"", "K","M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc", "Ud", "Dd", "Td", "Qad", "Qid", "Sxd", "Spd", "Ocd", "Nod", "Vg", "Uvg", "Dvg", "Tvg", "Qavg", "Qivg", "Sxvg", "Spvg", "Ocvg", "Novg", "Tg", "Utg", "Dtg", "Ttg", "Qatg", "Qitg", "Sxtg", "Sptg", "Octg", "Notg", "Qag", "Uqag", " qag", "Tqag", "Qaqag", "Qiqag", "Sxqag", "Spqag", "Ocqag", "Noqag", "Qig", "Uqig", " Dqig", " Tqig", "Qaqig", "Qiqig", "Sxqig", "Spqig", "Ocqig", "Noqig", "Sxg"};
        int i;
 
        for (i = 0; i < Abbrevs.Length; i++)
            if (num <= 999)
                break;
            else num = BigDouble.Floor((num / 100f) / 10f);
 
        if (num == BigDouble.Floor((num)))
            result = num.ToString() + Abbrevs[i];
        else result = num.ToString("F2") + Abbrevs[i];
        return result;
    }

}
