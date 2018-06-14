using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CooldownSkillScript : MonoBehaviour {
    public Image lockImage;
    public float duration = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lockImage.fillAmount >= 0)
        {
            lockImage.fillAmount -= 1.0f / duration * Time.deltaTime;
        }
    }

}
