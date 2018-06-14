using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fearhandler : MonoBehaviour {

    public int fearMax = 500;
    public int fearCurrent;
    public float fearprogres;
    public int decayNumber = 5;
    float timerSec; 
    public int timerSecRound = 0;
    int timerSecRoundOld = 0;
    public Scrollbar scrollie;
    public bool winner = false;
    public GameObject levelComplete;
	
	void Update () {
        if (!winner) // if bar is not full do your thing else stop decaying. 
        {
            if (fearCurrent >= fearMax)
            {
                winner = true;

            }
            if(fearCurrent >= decayNumber) { SteadyDecay(decayNumber); }
         
        }
       
        fearprogres = 1f * (float)fearCurrent / (float)fearMax;
        scrollie.size = fearprogres;
	}
    // method to scare residents
    public void GetFearedBrother(int fearAmount)
    {
        fearCurrent += fearAmount;
    }
   
    void SteadyDecay(int decayAmount)
    {
        timerSec -= Time.deltaTime;
        timerSecRound = (int)timerSec;
        if (timerSecRound  != timerSecRoundOld)
        {
            timerSecRoundOld = timerSecRound;
            fearCurrent -= decayAmount;
        }
         
    }

}
