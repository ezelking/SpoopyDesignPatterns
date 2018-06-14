using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CooldownSkillScript : MonoBehaviour {
    public Image lockImage;
    // Enter CooldownTime of skill
    public float duration = 5;

    void Start()
    {

    }

    void Update()
    {
        if (lockImage.fillAmount >= 0)
        {
            lockImage.fillAmount -= 1.0f / duration * Time.deltaTime;
        }
    }

}
