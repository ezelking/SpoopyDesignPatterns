using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantFearing : MonoBehaviour, IFearing {


    public bool fearingOn = false;
    public int fearamount = 1;


    public int GetFearAmount()
    {
        return fearingOn ? fearamount : 0;
    }

    public void ToggleFearing()
    {
        fearingOn = true;
    }
}
