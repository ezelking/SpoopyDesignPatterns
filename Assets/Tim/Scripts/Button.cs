using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {
    public Color highlightColor;
    Color textColor;
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        textColor = text.color;
	}
	
    public void Highlight()
    {
        text.color = Color.red;
    }

    public void StopHighlight()
    {
        text.color = textColor;
    }

    public void Click()
    {
        if (gameObject.name == "Retry Text") {
            SceneManager.LoadScene("EasyLevel");
        }
        else if (gameObject.name == "Exit Text") {
            Application.LoadLevel("Marc");
        }
        else if (gameObject.name == "Main Menu Text")
        {
            Application.LoadLevel("Marc");
        }
        else if (gameObject.name == "Restart Text")
        {
            Application.LoadLevel("EasyLevel");
        }
        else if (gameObject.name == "Quit Text")
        {
            Application.Quit();
        }

    }
}
