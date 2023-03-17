using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameParameters gameParameters;
    public GameObject timeCycler;
    DayAndNightCycler dayNightCycle;

    private void Awake()
    {
        dayNightCycle = timeCycler.GetComponent<DayAndNightCycler>();   
        dayNightCycle.enabled = gameParameters.enableDayNightCycle;
        
    }
}
