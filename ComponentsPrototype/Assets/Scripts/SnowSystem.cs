using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSystem : MonoBehaviour
{
    public GameParameters gameParameters;

    public ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GameObject.FindGameObjectWithTag("Snow").GetComponent<ParticleSystem>();

        systemOnOrOff();
    }

    void systemOnOrOff() { 

        if (!gameParameters.enableSnow) {
            particleSystem.Stop();
        }

        if(gameParameters.enableSnow)
        {
            particleSystem.Play();
        }
    }
}
