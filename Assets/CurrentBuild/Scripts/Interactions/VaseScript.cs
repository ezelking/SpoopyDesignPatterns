using UnityEngine;
using System.Collections;

public class VaseScript : MonoBehaviour {

    public GameObject fearCollector; 
    bool startedThePush = false;
    float startHeight;
    private AudioSource breakSound;
    Rigidbody rb;
    [Range(0.0F, 2.0F)] public float strength = 1;

    bool broken;
    
    void Start () {
        fearCollector = GameObject.Find("FearCollector");
        breakSound = GetComponent<AudioSource>();
        startHeight = this.transform.position.y;
        rb = GetComponent<Rigidbody>();
        broken = false;
	}
	
	void FixedUpdate () {
        if (this.transform.position.y < startHeight - 1 && rb.velocity.y >= -0.001 && !broken)
        {
            Break();
        }

       if( gameObject.transform.GetChild(2).childCount <= 0)
        {
            fearCollector.GetComponent<Fearing>().interactions.Remove(gameObject);
            Destroy(gameObject);
        }
	}

    // Replaces the vase for shatters.
    public void Break()
    {
        transform.Find("BrokenVase").gameObject.SetActive(true);
        transform.Find("Vase").gameObject.SetActive(false);
        if (!breakSound.isPlaying)
        {
            breakSound.Play();
        }
        broken = true;
    }

    public void Push()
    {
        if (!startedThePush)
        {
            GetComponentInParent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * (200 * strength));
            startedThePush = true;
        }
    }

    // Draws a line in the direction the vase will go and shows the aproximate force it will have.
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward) * (3 * strength)));
    }

}
