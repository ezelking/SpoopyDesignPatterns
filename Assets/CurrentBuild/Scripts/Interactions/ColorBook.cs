using UnityEngine;
using System.Collections;

public class ColorBook : MonoBehaviour {

	// This script gives each book a randomly generated color.

	void Start () {
        gameObject.GetComponent<Renderer>().material.color = new Color((float) Random.Range(0,255) / 255, (float) Random.Range(0, 255) / 255, (float) Random.Range(0, 255) / 255);
    }
}
