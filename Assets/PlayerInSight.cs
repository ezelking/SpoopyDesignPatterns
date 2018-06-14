using UnityEngine;
using System.Collections;

public class PlayerInSight : MonoBehaviour {
    public Fearing methodgetter;
    public GameObject player;

    bool cleansing;
    public float timer;
	// Use this for initialization
	void Start () {
        timer = 3f;
	}

    // Update is called once per frame
    void Update()
    {

        if (cleansing) {
            timer -= Time.deltaTime;
            if (this.gameObject.GetComponent<residentMovement>().currentState != "investigate")
            {
                this.gameObject.GetComponent<residentMovement>().investigate(this.transform.position);
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else
        {
            timer = 3f;
        }

        if (timer <= 0)
        {
            if (methodgetter.checkif1isin2(player, this.gameObject))
            {
                Application.LoadLevel("GameOver");
            }
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            cleansing = false;
        }


            if(this.GetComponent<FieldOfView>().visibleTargets.Count > 0)
        {
            cleansing = true;
        }
               

    }

}
