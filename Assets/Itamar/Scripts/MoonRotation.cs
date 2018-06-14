using UnityEngine;
using System.Collections;

public class MoonRotation : MonoBehaviour {
    //rotater of the moon around the empty object inside the house at 0,0,0
    public float speed;

    void Update()
    {
        //moon goes round and round
        //speed is a variable set in the UNITY EDITOR!!
        transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
    }
}
