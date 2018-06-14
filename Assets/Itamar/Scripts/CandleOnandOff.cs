using UnityEngine;
using System.Collections;

public class CandleOnandOff : MonoBehaviour {
    // WARNING THIS SCRIPT IS NO LONGER USED.
    // This script is the light switcher
    public GameObject Lighting;
    
    //switches the light to the other state
    public void Check()
    {
        if(Lighting.activeSelf == true)
        {
            Off();
        }
        else
        {
            On();
        }
    }

    public void Off()
    {
       Lighting.gameObject.SetActive(false);
    }

    public void On()
    {
        Lighting.gameObject.SetActive(true);
    }
}
