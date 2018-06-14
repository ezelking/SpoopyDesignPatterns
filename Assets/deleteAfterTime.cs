using UnityEngine;
using System.Collections;

public class deleteAfterTime : MonoBehaviour {
    public float FinalTimer;
	// Use this for initialization
	void Start () {
	    FinalTimer = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        FinalTimer -= Time.deltaTime;
        if(FinalTimer <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
