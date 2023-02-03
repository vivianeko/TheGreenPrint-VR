using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class UpdateBlockStats : MonoBehaviour
{       
    public BlockPreset preset;
    public GameObject manager;

    public void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void StatsShow()
    {
        manager.GetComponent<SelectedBlockInfo>().updatestats(preset);
    }

    public void StatsHide()
    {
        manager.GetComponent<SelectedBlockInfo>().hidestats();
    }
}
