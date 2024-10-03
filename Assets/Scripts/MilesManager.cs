using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MilesManager: MonoBehaviour
{

    public static MilesManager Instance;
    [SerializeField] private TextMeshProUGUI milesText;
    private float milesTraveled;
    private bool isTraveling;
    //public float speedMilesPerSecond = 0.03;
    private float milesCounter = 0f;
    private float currMile;
    private void Awake() {
        Instance = this;
        milesTraveled = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isTraveling)
        {
            return;
        }

        
        milesTraveled += Time.deltaTime * 80;

        currMile = (float)Math.Round(milesTraveled/1760f, 2, MidpointRounding.AwayFromZero);

        milesText.text = currMile + " Miles";
        

    }

    public void StartScript(){
        isTraveling  = true;
    }


    public float finalDistance() {
        return currMile;
    }
}
