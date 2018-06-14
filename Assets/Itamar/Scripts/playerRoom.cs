using UnityEngine;
using System.Collections;

public class playerRoom : MonoBehaviour {
    //NOTE THIS SCRIPT IS NOT USED
    //script to give the player the tag of the room he/she is in, this would work with the exorcist for cleansing in each room
    public GameObject lobby;

    Collider lobbyTag;

    public bool lobbyActive;

	// Use this for initialization
	void Start () {
        lobbyTag = lobby.GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
        if(lobbyTag)
        {
            lobbyActive = true;
        }
	}

    //if the player hit the collider of the room it should get the tag of that room
    //empty cause we don't use it
    void OnCollisionEnter(Collision collision)
    {

    }
}
