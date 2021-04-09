using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : Singleton<AnalyticsManager>
{

  public void deathCountAnalytics(string eventname)
    {
        Analytics.CustomEvent(eventname);
    }

    public void levelCompleted(string eventname)
    {
        Analytics.CustomEvent(eventname);
    }
}
