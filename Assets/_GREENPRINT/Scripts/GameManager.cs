using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using Normal.Realtime;

public class GameManager : MonoBehaviour
{
    #region Singleton

    static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(this);
    }
    #endregion

    public BlockPreset block = null;
    public GameObject[] blocks;    
    [Space]
    public GameObject LaborIcon;
    public GameObject PowerIcon;
    public GameObject WaterIcon;
    public GameObject FoodIcon;    
    [Space]
    public int Population = 0;
    [Space]
    public int CurrentLabor = 0;
    public int CurrentPower = 0;
    public int CurrentWater = 0;
    public int CurrentFood = 0;

    [Space]
    public TextMeshProUGUI statsText;
    public TextMeshProUGUI populationCount;   

    #region placeblock
    public void Start()
    {
        CheckBlocks();
        UpdateStats();
        //InvokeRepeating("NextDay", 0, 20);
    }


    public void updateblock(BlockPreset _block)
    {
        block = _block;
    }

    public void placeblock()
    {
        Realtime.Instantiate(block.Prefab.name, GameObject.FindGameObjectWithTag("reticle").transform.position, Quaternion.identity, options: default);
        //onplaceblock(block);
        CheckBlocks();
    }
    #endregion

   public void onplaceblock(BlockPreset block)
    {
        Population += block.Population;
        CurrentLabor = CurrentLabor + block.outLabor - block.inLabor;
        CurrentPower = CurrentPower + block.outPower - block.inPower;
        CurrentWater = CurrentWater + block.outWater - block.inWater;
        CurrentFood = CurrentFood + block.outFood - block.inFood;       
        UpdateStats();
    }

    public void CheckBlocks()
    {
        Population = 0;
        CurrentLabor = 0;
        CurrentPower = 0;
        CurrentWater = 0;
        CurrentFood = 0;

        blocks = GameObject.FindGameObjectsWithTag("block");
        foreach(GameObject bl in blocks)
        {
            BlockPreset pr = bl.GetComponent<UpdateBlockStats>().preset;
            Population += pr.Population;
            CurrentLabor = CurrentLabor + pr.outLabor - pr.inLabor;
            CurrentPower = CurrentPower + pr.outPower - pr.inPower;
            CurrentWater = CurrentWater + pr.outWater - pr.inWater;
            CurrentFood = CurrentFood + pr.outFood - pr.inFood;
        }
        UpdateStats();        
    }
    

    #region stats
    public void UpdateStats()
    {
        if (CurrentLabor < 0)
            LaborIcon.SetActive(true);
        else
            LaborIcon.SetActive(false);

        if (CurrentPower < 0)
            PowerIcon.SetActive(true);
        else
            PowerIcon.SetActive(false);

        if (CurrentWater < 0)
            WaterIcon.SetActive(true);
        else
            WaterIcon.SetActive(false);

        if (CurrentFood < 0)
            FoodIcon.SetActive(true);
        else
            FoodIcon.SetActive(false);

        string n = Environment.NewLine;
        statsText.text ="  // Available Labor: " + CurrentLabor + "hrs" + "  // Available Power: " + CurrentPower + "kw/hr" + n+ "  // Available Water: " + CurrentWater + "gl" + "  // Available Food: " + CurrentFood + "lbs";
        populationCount.text = Population.ToString();       
    }     
    #endregion

    

}
