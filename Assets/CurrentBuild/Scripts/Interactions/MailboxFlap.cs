using UnityEngine;
using System.Collections;

public class MailboxFlap : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (gameObject.GetComponent<AreaTaunt>().residentThatNeedsToCloseMe != null)
        {
            transform.parent.GetChild(1).GetChild(2).gameObject.SetActive(true);
            transform.parent.GetChild(1).GetChild(3).gameObject.SetActive(false);
        }
        else
        {
            transform.parent.GetChild(1).GetChild(2).gameObject.SetActive(false);
            transform.parent.GetChild(1).GetChild(3).gameObject.SetActive(true);
        }
	}
}
