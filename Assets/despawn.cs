using UnityEngine;
using System.Collections;

public class despawn : MonoBehaviour {
    int timer;
    int despawnTime;

    // Use this for initialization
    void Start () {
        timer = 0;
        despawnTime = Random.Range(100, 125);
    }
	
	// Update is called once per frame
	void Update () {
        timer++;

        if (timer > despawnTime)
        {
            Destroy(gameObject);
        }
	}
}
