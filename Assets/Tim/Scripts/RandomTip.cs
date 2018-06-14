using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomTip : MonoBehaviour {

    public int tipNr;
    string[] tip = new string[10];

	// Use this for initialization
	void Start () {
        tip[0] = "Use the mailbox or a window to lure residents.";
        tip[1] = "Try Breaking the chandelier or blowing out candles to make it darker and scarier for the residents.";
        tip[2] = "The first few seconds of the game can be very useful because all the residents start in the lobby.";
        tip[3] = "Each resident has his own preference for which rooms they might want to visit.";
        tip[4] = "As a ghost: Use your spectral vision to find the residents by pressing 1.";
        tip[5] = "As a ghost you can move threw walls.";
        tip[6] = "You can lock door by clicking the right mouse button.";
        tip[7] = "If you leave a resident alone he will start settling down and you will have to scare him again.";
        tip[8] = "Check the clock every so often to make sure you don't run out of time.";
        tip[9] = "You must scare all residents away to complete the level.";
        tipNr = Random.Range(1, tip.Length);
        gameObject.GetComponent<Text>().text = tip[tipNr];
    }

    public void NewTip()
    {
        tipNr = Random.Range(0, tip.Length);
        gameObject.GetComponent<Text>().text = tip[tipNr];
    }
}
