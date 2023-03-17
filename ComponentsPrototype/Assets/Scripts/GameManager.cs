using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameParameters gameParameters;

    private void Awake()
    {
        // ...
        GetComponent<DayNightCycle>().enabled = gameParameters.enableDayNightCycle;
    }
}