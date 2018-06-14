using UnityEngine;
using System.Collections;

public class SprinklerSprinkels : MonoBehaviour {
    public bool sprinkling;
    public GameObject water;
    GameObject waterMade;
    public float timer;
    public float timertwo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if(sprinkling)
        {
            timertwo--;
            timer -= Time.deltaTime;
            transform.Rotate(Vector3.up * Time.deltaTime * 90);
            if (timertwo <= 0)
            {
                waterMade = Instantiate(water, this.transform.GetChild(1).transform.position, this.transform.rotation, this.transform.parent.transform) as GameObject;
                waterMade.gameObject.GetComponent<Rigidbody>().AddForce((this.transform.GetChild(1).transform.position - this.transform.position).normalized.x * 250f, ( (this.transform.GetChild(1).transform.position - this.transform.position).normalized.y + 1f) * 250f, (this.transform.GetChild(1).transform.position - this.transform.position).normalized.z * 250f);
                timertwo = 5;
            }
        }
    if(timer <= 0)
        {
            sprinkling = false;
            this.GetComponent<Interaction>().fearingOn = false;
        }
	}

    public void Sprinkel()
    {
        sprinkling = true;
        timer = 5f;
    }
}
