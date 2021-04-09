using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsController : MonoBehaviour
{
    public string eventname;

    public void recordNumberOfDeathsEvent()
    {
        AnalyticsManager.Instance.deathCountAnalytics(eventname);
    }

    public void recordCompletedLevel()
    {
        AnalyticsManager.Instance.levelCompleted(eventname);
    }

}
