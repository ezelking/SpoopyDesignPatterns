using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Loader : MonoBehaviour
{

    public GameObject fearing;

	// Use this for initialization
	void Awake () {
	    //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
	    if (Fearing.instance == null)

	        //Instantiate gameManager prefab
	        Instantiate(fearing);
    }
	
}
