using UnityEngine;
using System.Collections;

public class despawn : MonoBehaviour {
    int timer;
    int despawnTime;

    // This script deletes the gameobject it's attached to after a while.
    // Used for the vase shards.

    void Start () {
        timer = 0;
        despawnTime = Random.Range(100, 125);
    }
	
	void Update () {
        timer++;

        if (timer > despawnTime)
        {
            Destroy(gameObject);
        }
	}
}
