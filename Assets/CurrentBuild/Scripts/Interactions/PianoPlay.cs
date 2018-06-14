using UnityEngine;
using System.Collections;

public class PianoPlay : MonoBehaviour {
    public bool isPlaying = false;
    public float timer;

    public GameObject soundIcon;

    public  AudioSource pianoPlay;
    // Use this for initialization
    void Start () {
        pianoPlay = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (isPlaying)
        {
            if (!pianoPlay.isPlaying)
            {
                pianoPlay.Play();
            }
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            this.GetComponentInParent<Interaction>().fearingOn = false;
            pianoPlay.Stop();
            isPlaying = false;
        }
    }

    public void Play()
    {
        isPlaying = true;
        timer = 7f;
        Instantiate(soundIcon, transform.position + (transform.up * 2 + transform.forward* -2), transform.rotation);
    }
}
