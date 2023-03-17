using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Parameters", menuName = "Scriptable Objects / Game Parameters Menu", order = 10)]
public class GameParameters : ScriptableObject
{
    public bool enableDayNightCycle;            //enables option to turn on/off day night cycle
    public float lengthOfDayInSeconds;          //enables option to change length of game day
    public float timeOfDayRatio;                //enables option to choose which time of the day the game starts (day time, dawn, night time and so on...)
}
