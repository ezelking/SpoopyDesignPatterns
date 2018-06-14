using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleEye : MonoBehaviour
{
    bool onOff = false;
    public Image EyeOffIcon;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (onOff)
            {
                onOff = false;
                EyeOffIcon.fillAmount = 1;
            }
            else
            {
                onOff = true;
                EyeOffIcon.fillAmount = 0;
            }
        }
    }
}

