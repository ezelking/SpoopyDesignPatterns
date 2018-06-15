using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFearing
{
    // Use this for initialization
    int GetFearAmount();
    void ToggleFearing();
}