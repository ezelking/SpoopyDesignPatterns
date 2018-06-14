using UnityEngine;
using System.Collections;

public class ClockTicking : MonoBehaviour {
    public bool back;

	// Use this for initialization
	void Start () {
        back = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (back)
        {
            transform.Rotate(0, 0, 0.33f);
        } else
        {
            transform.Rotate(0, 0, -0.33f);
        }
        if (transform.localRotation.z > 0.07f)
        {
            transform.localEulerAngles = new Vector3(0, 0, 8f);
            back = false;
        }
        if (transform.localRotation.z < -0.07f)
        {
            transform.localEulerAngles = new Vector3(0, 0, -8f);
            back = true;
        }
    }
}
