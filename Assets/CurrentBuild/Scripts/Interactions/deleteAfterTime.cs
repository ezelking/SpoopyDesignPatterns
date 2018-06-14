using UnityEngine;
using System.Collections;

public class deleteAfterTime : MonoBehaviour {
    public float FinalTimer;
	// Use this for initialization
	void Start () {
	    FinalTimer = 1f;
	}
	
	
	void Update () { // water dissapears after 1sec.
        FinalTimer -= Time.deltaTime;
        if(FinalTimer <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
