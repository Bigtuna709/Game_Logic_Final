using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : Singleton<AnalyticsManager>
{

   //Method for deathcount for analytics using a string in which will be placed in the inspector. Using a normal customevent in the analytic package
  public void deathCountAnalytics(string eventname)
    {
        Analytics.CustomEvent(eventname);
    }

    //Method for levelCompleted for analytics using a string in which will be placed in the inspector. Using a normal customevent in the analytic package
    public void levelCompleted(string eventname)
    {
        Analytics.CustomEvent(eventname);
    }
}
