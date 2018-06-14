using UnityEngine;
using System.Collections;

public class VaseScript : MonoBehaviour {
    public GameObject fearCollector;
    bool startedThePush = false;
    float startHeight;
    private AudioSource breakSound;
    Rigidbody rb;
    [Range(0.0F, 2.0F)] public float strength = 1;

    // Use this for initialization
    void Start () {
        fearCollector = GameObject.Find("FearCollector");
        breakSound = GetComponent<AudioSource>();
        startHeight = this.transform.position.y;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (this.transform.position.y < startHeight - 1 && rb.velocity.y >= -0.001)
        {
            Break();
        }

       if( gameObject.transform.GetChild(2).childCount <= 0)
        {
            fearCollector.GetComponent<Fearing>().interactions.Remove(gameObject);
            Destroy(gameObject);
        }
	}


    public void Break()
    {
        transform.Find("BrokenVase").gameObject.SetActive(true);
        transform.Find("Vase").gameObject.SetActive(false);
        if (!breakSound.isPlaying)
        {
            breakSound.Play();
        }
    }

    public void Push()
    {
        if (!startedThePush)
        {
            GetComponentInParent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * (350 * strength));
            startedThePush = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward) * (3 * strength)));
    }

}
