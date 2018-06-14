using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LockCountdown : MonoBehaviour {
    public Image lockImage;
    public float duration = 10;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        lockImage.fillAmount -= 1.0f / duration * Time.deltaTime;
        if(lockImage.fillAmount <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

}
