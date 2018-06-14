using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LockCountdown : MonoBehaviour {
    public Image lockImage;
    // Use duration of the interaction its attached to
    public float duration = 10;

    void Start () {

	}

	void Update () {
        lockImage.fillAmount -= 1.0f / duration * Time.deltaTime;
        if(lockImage.fillAmount <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

}
