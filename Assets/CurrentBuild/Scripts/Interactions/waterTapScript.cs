using UnityEngine;
using System.Collections;

public class waterTapScript : MonoBehaviour {
    /* 
    Put this on the Sink prefab.
    Turns the mesh renderer on and off with boolean.
    slimeStream is the "Stream"Part of the sink model/prefab.
    Stream part should have the animatedTiledTexture on it.
    */
    public bool isTurnedOn;
    public float timer;

    public GameObject soundIcon;

    public GameObject slimeStream;
    private Renderer myRenderer;

    void Start ()
    {
        isTurnedOn = false;
        myRenderer = slimeStream.GetComponent<Renderer>();
    }
	


	void Update ()
    {
        if (isTurnedOn)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            this.GetComponentInParent<Interaction>().fearingOn = false;
            myRenderer.enabled = false;
            isTurnedOn = false;
        }
    }


    public void Play()
    {
        isTurnedOn = true;
        myRenderer.enabled = true;
        timer = 5f;
        Instantiate(soundIcon, transform.position + (transform.up * 3), transform.rotation * Quaternion.Euler(0, 90, 0));
    }
}
