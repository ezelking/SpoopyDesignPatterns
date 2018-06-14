using UnityEngine;
using System.Collections;

public class MoonRotation : MonoBehaviour {

    public float speed;

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
    }
}
