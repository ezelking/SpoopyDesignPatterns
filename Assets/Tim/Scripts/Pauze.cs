using UnityEngine;
using System.Collections;

public class Pauze : MonoBehaviour {

    GameObject Menu;
    public bool paused;
    //public GameObject gameTip;

	// Use this for initialization
	void Start () {
        Menu = transform.GetChild(0).gameObject;
        paused = false;
        //gameTip = transform.GetChild(0).GetChild(5).GetChild(1).GetComponent<RandomTip>().NewTip();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            transform.GetChild(0).GetChild(5).GetChild(1).GetComponent<RandomTip>().NewTip();
        }

        if (paused)
        {
            Time.timeScale = 0;
            Menu.SetActive(true);
            AudioListener.pause = true;
            
            Cursor.visible = true;
          
        }
        else
        {
            Time.timeScale = 1;
            Menu.SetActive(false);
            AudioListener.pause = false;

            Cursor.visible = false;
           
        }
	}
}
