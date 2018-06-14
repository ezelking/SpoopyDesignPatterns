using UnityEngine;
using System.Collections;

public class spiegelActive : MonoBehaviour {

    public void Break()
    {
        transform.Find("SpiegelShards").gameObject.SetActive(true);
        transform.Find("SpiegelHeel").gameObject.SetActive(false);
    }

}
