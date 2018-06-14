using UnityEngine;
using System.Collections;

public class chandelierCrash : MonoBehaviour {
    public float distToGround;
    public float timer;
    public bool isFalling;
    public bool startdecay;
    public float startingpos;
    public float startingposboxony;
    float startHeight;
    public GameObject fearCollector;
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        fearCollector = GameObject.Find("FearCollector");
        startingpos = transform.position.y;
        startingposboxony = GetComponent<BoxCollider>().center.y;
        rb = GetComponent<Rigidbody>();
        startHeight = this.transform.position.y;
    }
	 
    void Update()
    {
        GetComponent<BoxCollider>().center = new Vector3(GetComponent<BoxCollider>().center.x, startingposboxony + (startingpos - transform.position.y), GetComponent<BoxCollider>().center.z);


        if (isFalling)
        {
            this.transform.GetComponent<Rigidbody>().useGravity = enabled;
        }
        if (IsGrounded())
        {
            //startdecay = true;
           
            
        }
        if (startdecay == true){
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                //Destroy(gameObject);
                //fearCollector.GetComponent<Fearing>().interactions.Remove(gameObject);
                Destroy(gameObject);
            }
        }

        if (rb.velocity.y >= -0.001 && isFalling && this.transform.position.y < startHeight - 1)
        {
            startdecay = true;
            Break();
        }
    }


    bool IsGrounded()
    {
            if (Physics.Raycast(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), -Vector3.up, distToGround + 0.1f) || Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f) || Physics.Raycast(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), -Vector3.up, distToGround + 0.1f)) return true;

            return false;

        }

    public void Break()
    {
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            transform.GetChild(1).GetChild(i).Find("BrokenLamp").gameObject.SetActive(true);
            transform.GetChild(1).GetChild(i).Find("Lamp").gameObject.SetActive(false);
        }
    }
    
}
