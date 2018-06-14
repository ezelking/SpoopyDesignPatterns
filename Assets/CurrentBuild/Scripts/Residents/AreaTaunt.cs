using UnityEngine;
using System.Collections;

public class AreaTaunt : MonoBehaviour {
    public GameObject checkspace;
    public bool TauntReady = false;
    public GameObject residentThatNeedsToCloseMe;


    //om dit te laten werken moet je eerst ergens deze callBack benoemen naar de resetmethode voor het gewenste object.
    public System.Action callBack;


    void Start()
    {
        checkspace = GameObject.Find("FearCollector");
    }


    void FixedUpdate()
    {   // checks if the window is done with its opening behavior.
        // then assigns a resident in the nearbyarea to close it.  
        // uses investigate from residentmovement.
        if (TauntReady)
        {   
            
            foreach (GameObject resident in checkspace.GetComponent<Fearing>().residents)
            {
                if (residentThatNeedsToCloseMe == null)
                {
                    if (checkspace.GetComponent<Fearing>().checkif1isin2(resident, this.gameObject))
                    {
                        if (resident.GetComponent<residentMovement>().currentState != "investigate")
                        {
                            resident.GetComponent<residentMovement>().investigate(this.transform.position);
                            residentThatNeedsToCloseMe = resident;
                        }
                    }
                }
            }        
        }
       
        if (residentThatNeedsToCloseMe != null)
        {
            if (residentThatNeedsToCloseMe.GetComponent<residentMovement>().currentState != "investigate")
            {
                residentThatNeedsToCloseMe.GetComponent<residentMovement>().investigate(this.transform.position);
            }
            if (residentThatNeedsToCloseMe.GetComponent<UnityEngine.AI.NavMeshAgent>().stoppingDistance + 0.5f >= Vector3.Distance(residentThatNeedsToCloseMe.transform.position, this.transform.position))
            {
                TauntReady = false;
                residentThatNeedsToCloseMe = null;
                this.transform.parent.transform.GetChild(1).transform.GetChild(0).GetComponent<HandleWindow>().ResetWindowInteraction();
            }

        }
    }
}
