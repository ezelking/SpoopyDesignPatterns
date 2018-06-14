using UnityEngine;
using System.Collections;

public class HighlightHandler : MonoBehaviour {
    public float value;
    public Color valueC;
    public GameObject shadedObject;
    // Use this for initialization



    void Awake() 
    {
        shadedObject = this.gameObject;
    }
    void Start () { // Makes it possible to use one shader for all the highlights but with different settings
        shadedObject.GetComponent<Renderer>().material.SetFloat("_Outline", value);
        shadedObject.GetComponent<Renderer>().material.SetColor("_OutlineColor", valueC);
    }
	

	void Update () {
        shadedObject.GetComponent<Renderer>().material.SetFloat("_Outline", value);
        shadedObject.GetComponent<Renderer>().material.SetColor("_OutlineColor", valueC);
    }
}
