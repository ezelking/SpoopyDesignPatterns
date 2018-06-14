using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {
    //takes care of the lighting timers and such
    //timer for the length of the strike and when it will strike again

    public GameObject lStandard;
    public float interval;
    public float strikeLength;

    private float previousStrikeLength;
    private float checkInterval;
    private bool lightningOn;

    void Start()
    {
        previousStrikeLength = strikeLength;
        lightningOn = false;
    }

    void Update()
    {
        //time it takes for a new strike, is random between x and x
        checkInterval = Random.Range(0, 120);
        if(checkInterval == interval)
        {
            //STRIKE
            LightningStrike();
            lightningOn = true;
        }

        //checks if the lighting is on
        if(lightningOn)
        {
            //length of the strike, time
            strikeLength -= Time.deltaTime;
            if (strikeLength <= 0f)
            {
                //puts the intensity back to zero, without turning the actual object off
                lStandard.GetComponent<Light>().intensity = 0f;
                lightningOn = false;
                strikeLength = previousStrikeLength;
            }
        }
        
    }

    void LightningStrike()
    {
        //sets the light intensity to the max
        lStandard.GetComponent<Light>().intensity = 8f;
    }
}
