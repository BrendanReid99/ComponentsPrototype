using System.Collections;
using UnityEngine;

public class DayAndNightCycler : MonoBehaviour
{
    public GameParameters gameParameters;
    public Transform starsTransform;

    private float starsRefreshRate;
    private float rotationAngleStep;
    private Vector3 rotationAxis;

    private void Awake()
    {
        //apply initial rotation on the stars
        starsTransform.rotation = Quaternion.Euler(gameParameters.timeOfDayRatio * 360.0f, -30.0f, 0.0f);

        //compute relevant calculation parameters
        starsRefreshRate = 0.1f;
        rotationAxis = starsTransform.right;
        rotationAngleStep = 360.0f * starsRefreshRate / gameParameters.lengthOfDayInSeconds; 
    }

    private void Start()
    {
        StartCoroutine("UpdateStars");
    }

    private IEnumerator UpdateStars()
    {
        while (true) {
            starsTransform.Rotate(rotationAxis, rotationAngleStep, Space.World);
            yield return new WaitForSeconds(starsRefreshRate);
        }
    }
}
