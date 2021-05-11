using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class TimeScript
{
    public TMP_Text timertext;
    public Image timericon;

    public float StartTime = 30;

    public TimeScript()
    {
        timertext.text = StartTime.ToString("0");
        timericon.gameObject.SetActive(false);
    }
        
    
}
