using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

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
        checkInterval = Random.Range(0, 120);
        if(checkInterval == interval)
        {
            LightningStrike();
            lightningOn = true;
        }

        if(lightningOn)
        {
            strikeLength -= Time.deltaTime;
            if (strikeLength <= 0f)
            {
                
                lStandard.GetComponent<Light>().intensity = 0f;
                lightningOn = false;
                strikeLength = previousStrikeLength;
            }
        }
        
    }

    void LightningStrike()
    {
        lStandard.GetComponent<Light>().intensity = 8f;
    }
}
