﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger1 : MonoBehaviour
{
    TipsTriggerScript tipsScript;

    private void Awake()
    {
        tipsScript = FindObjectOfType<TipsTriggerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            tipsScript.OnRoombotTipTriggerHit();
        }
    }
}
