﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public int goleDelayCount;
    private int goalCount;
    public static bool ClearFlag
    {
        get; set;
    }

    private void Start()
    {
        ClearFlag = false;
        goalCount = goleDelayCount + 1;
    }
    private void Update()
    {
        if (goalCount < goleDelayCount)
        {
            goalCount++;
            if (goalCount == goleDelayCount)
            {
                SceneManager.LoadScene("ResultScene");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SystemInfo.supportsVibration)
            {
                Handheld.Vibrate();
            }
            goalCount = 0;
            ClearFlag = true;
        }
    }
}
