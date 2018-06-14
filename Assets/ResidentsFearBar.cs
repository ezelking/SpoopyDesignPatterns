using UnityEngine;
using System.Collections;

public class ResidentsFearBar : MonoBehaviour {
    public GameObject fearBar;


    void Update()
    {
        if(fearBar.GetComponent<Fearhandler>().winner == true)
        {
            this.GetComponent<residentMovement>().FleeFromHouse();
         //   GameObject.Find("FearCollector").GetComponent<Fearing>().residents.Remove(this.gameObject);
        }
    }

    }
