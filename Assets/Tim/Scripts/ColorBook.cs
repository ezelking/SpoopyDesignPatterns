using UnityEngine;
using System.Collections;

public class ColorBook : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = new Color((float) Random.Range(0,255) / 255, (float) Random.Range(0, 255) / 255, (float) Random.Range(0, 255) / 255);
    }
}
