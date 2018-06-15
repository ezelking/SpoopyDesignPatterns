using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullFearing : MonoBehaviour, IFearing {
    public int GetFearAmount() {
        return 0;
    }

    public void ToggleFearing()
    {

    }
}
