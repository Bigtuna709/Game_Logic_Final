using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsController : MonoBehaviour
{
    public string eventname;

    //Using the Analytic Manager (Singleton) call the method deathCountAnalytics to count # of times you die.
    public void recordNumberOfDeathsEvent()
    {
        AnalyticsManager.Instance.deathCountAnalytics(eventname);
    }

    //Using the Analytic Manager (Singleton) call the method levelCompleted to count # of times you die.
    public void recordCompletedLevel()
    {
        AnalyticsManager.Instance.levelCompleted(eventname);
    }

}
