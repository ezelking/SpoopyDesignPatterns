using UnityEngine;
using System.Collections;

public class TVScript : MonoBehaviour {

    /* 
    Should be places on the TV prefab/model group.
    Turns the meshrenderer on and off.
    staticScreen is the "StaticScreen" Part of the sink model/prefab.
    StaticScreen should have the animatedTiledTexture on it.
    */
    public bool isTurnedOn;
    public float timer;

    public GameObject soundIcon;

    public GameObject staticScreen;
    private Renderer myRenderer;

    private AudioSource staticSound;

    void Start()
    {
        isTurnedOn = false;
        myRenderer = staticScreen.GetComponent<Renderer>();
        staticSound = GetComponent<AudioSource>();
    }



    void Update()
    {

        if (isTurnedOn)
        {
            if (!staticSound.isPlaying)
            {
                staticSound.Play();
            }
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            this.GetComponentInParent<Interaction>().fearingOn = false;
            staticSound.Stop();
            myRenderer.enabled = false;
            isTurnedOn = false;
        }
    }

    public void Play()
    {
        isTurnedOn = true;
        myRenderer.enabled = true;
        timer = 3f;
        Instantiate(soundIcon, transform.position + (transform.up * 2), transform.rotation * Quaternion.Euler(0, 90, 0));
    }
}

