using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BanishHandler : MonoBehaviour {
    float maxTimer = 3f;
    public Scrollbar scrollie;
    public GameObject timerHolder;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float timerBanish = 1f * timerHolder.GetComponent<PlayerInSight>().timer  / maxTimer;
        scrollie.size = timerBanish;
    }
}
