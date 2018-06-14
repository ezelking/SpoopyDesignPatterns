using UnityEngine;
using System.Collections;

public class LawnMowing : MonoBehaviour {
    public bool mowing;
    public float timer;
    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        if (mowing)
        {
            timer -= Time.deltaTime;
            GetComponent<Rigidbody>().velocity = transform.forward * 5f;
        }
        if (timer <= 0)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            mowing = false;
            this.GetComponent<Interaction>().fearingOn = false;
        }
    }
    public void MowingMower()
    {
        mowing = true;
        timer = 10f;
    }

}
