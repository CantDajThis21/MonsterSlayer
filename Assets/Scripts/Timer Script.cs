using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class TimerScript
{
    public TMP_Text timertext;
    public Image timericon;

    public float StartTime = 30;

    public TimerScript(){
        timertext.text = StartTime.ToString("0");
        timericon.gameObject.SetActive(false);
    }
        
    
}
