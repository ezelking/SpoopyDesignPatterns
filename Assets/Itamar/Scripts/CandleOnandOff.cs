using UnityEngine;
using System.Collections;

public class CandleOnandOff : MonoBehaviour {

    public GameObject Lighting;

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
