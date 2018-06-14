using UnityEngine;
using System.Collections;

public class RotateCanvasToplayer : MonoBehaviour {
    public GameObject player;

	// Update is called once per frame
	void Update () {
        Vector3 heading = player.transform.position - this.transform.position;
        Quaternion direction = Quaternion.LookRotation(heading);
        this.transform.rotation = direction;
    }
}
