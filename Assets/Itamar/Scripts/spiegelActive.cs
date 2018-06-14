using UnityEngine;
using System.Collections;

public class spiegelActive : MonoBehaviour {
    //shards the mirror

    public GameObject fearCollector;

    bool timer;
    int time;

    void start()
    {
        //fear for the mirror
        fearCollector = GameObject.Find("FearCollector");
        time = 0;
        timer = false;
    }

    //fearing itself and the removing of the mirror
    public void FixedUpdate()
    {
        if (timer)
        {
            time++;
        }

        if (time > 100){
            fearCollector.GetComponent<Fearing>().interactions.Remove(gameObject);
            Destroy(gameObject);
        }

    }
    //the breaking part of the mirror
    //simply by disabling the normal mirror and activating the model shards
    public void Break()
    {
        transform.Find("SpiegelShards").gameObject.SetActive(true);
        transform.Find("SpiegelHeel").gameObject.SetActive(false);

        timer = true;
    }

}
