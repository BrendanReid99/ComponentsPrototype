using UnityEngine;

[CreateAssetMenu(fileName = "Parameters", menuName = "Scriptable Objects Menu", order = 10)]
public class GameParameters : ScriptableObject
{
    public bool enableDayNightCycle; //allows us turn on / off day night cycle - good for testing later
    public float lengthofDay; //allows us to customise the length of the day (in seconds)
    public float initDayNightRatio; //modify which time of day it is 
}
