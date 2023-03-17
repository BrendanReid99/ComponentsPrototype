using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Diagnostics.Tracing;

public class DayAndNightCycler : MonoBehaviour
{
    public GameParameters gameParameters;
    public Transform starsTransform;

    private float starsRefreshRate;
    private float rotationAngleStep;
    private Vector3 rotationAxis;

    public TextMeshProUGUI timeOfDay;
    public float currentTime;
    int counter;


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


        StartCoroutine("UpdateStars");
    }

    void FixedUpdate() //EVERY 2 FRAMES == 1 MINUTE (GAME TIME)
    {
        counter += 1;
        if (counter % 4 == 0) { //modulo 4 here as length of day is set to 120 (2 minutes), if length of day was set to 60 (1 minute) we would change to modulo 2 (as fixedUpdate is every 2 frames)
            currentTime += 1;   //update the current time by 1 minute
        }

        float hours = Mathf.FloorToInt(currentTime / 60);
        float minutes = Mathf.FloorToInt(currentTime % 60);

        //resets clock to 00 hrs if greater than 24
        if (hours >= 24) {
            hours = 0;
        }

        timeOfDay.text = string.Format("{0:00}:{1:00}", hours,  minutes); //converts text into hours and minutes format

    }

    private IEnumerator UpdateStars()
    {
        while (true) {
            starsTransform.Rotate(rotationAxis, rotationAngleStep, Space.World);
            yield return new WaitForSeconds(starsRefreshRate);
        }
    }
}
