using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Diagnostics.Tracing;
using System.Collections.Generic;

public class DayAndNightCycler : MonoBehaviour
{
    public GameParameters gameParameters;
    public Transform starsTransform;
    //Light torch;

    private float starsRefreshRate;
    private float rotationAngleStep;
    private Vector3 rotationAxis;

    public TextMeshProUGUI timeOfDay;
    public TextMeshProUGUI dayofWeek;

    public float currentTime;
    private string[] days_in_week = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
    public int currentDay;
    int time_counter;
    //private bool torchOn;


    private void Awake()
    {
        //apply initial rotation on the stars
        starsTransform.rotation = Quaternion.Euler(gameParameters.timeOfDayRatio * 360.0f, -30.0f, 0.0f);

        //compute relevant calculation parameters
        starsRefreshRate = 0.1f;
        rotationAxis = starsTransform.right;
        rotationAngleStep = 360.0f * starsRefreshRate / gameParameters.lengthOfDayInSeconds;

    }

    void Start()
    {
        //set current time in game (360 minutes = 6am in game time i.e., 60 (00:00am) * 6 (hrs) = 360)
        currentTime = 360;
        currentDay = 1;

        StartCoroutine("UpdateStars");
    }

    void FixedUpdate() //EVERY 2 FRAMES == 1 MINUTE (GAME TIME)
    {
        time_counter += 1;
        if (time_counter % 4 == 0) { //modulo 4 here as length of day is set to 120 (2 minutes), if length of day was set to 60 (1 minute) we would change to modulo 2 (as fixedUpdate is every 2 frames)
            currentTime += 1;   //update the current time by 1 minute
        }

        float hours = Mathf.FloorToInt(currentTime / 60);
        float minutes = Mathf.FloorToInt(currentTime % 60); 

        //resets clock to 00 hrs if greater than 24
        if (hours >= 24) {
            hours = 0;
            currentTime = 0;
            currentDay++;
        }

        /*if (hours > 8 && hours < 21) {
            torchOn = false;
        }

        if (hours < 8 && hours >= 21) {
            
            
            torchOn = true;
        }
        */

        timeOfDay.text = string.Format("{0:00}:{1:00}", hours,  minutes); //converts text into hours and minutes format
        dayofWeek.text = string.Format("{0}", days_in_week[currentDay % 7]); //converts text into current day of week

    }

    private IEnumerator UpdateStars()
    {
        while (true) {
            starsTransform.Rotate(rotationAxis, rotationAngleStep, Space.World);
            yield return new WaitForSeconds(starsRefreshRate);
        }
    }
}
