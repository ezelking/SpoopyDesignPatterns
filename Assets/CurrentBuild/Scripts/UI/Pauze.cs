using UnityEngine;
using System.Collections;

public class Pauze : MonoBehaviour {

    // This script is used to pause the game.

    GameObject Menu;
    public bool paused;
    
	void Start () {
        Menu = transform.GetChild(0).gameObject;
        paused = false;
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            transform.GetChild(0).GetChild(5).GetChild(1).GetComponent<RandomTip>().NewTip();
        }

        if (paused)
        {
            Time.timeScale = 0; // Stops all FixedUpdate loops.
            Menu.SetActive(true);
            AudioListener.pause = true; // Pauses all audiosources.
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
          
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
