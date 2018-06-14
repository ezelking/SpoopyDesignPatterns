using UnityEngine;
using System.Collections;

public class StareDownResident : MonoBehaviour
{
    GameObject currentTarget;
    GameObject FearCollector;
    public float targetRange = 10;
    public bool staring;
    public float timer;


    void Start()
    {
        FearCollector = GameObject.Find("FearCollector");

    }

    void OnDrawGizmos() //  to understand how far the reach of the stare down is there is a sphere drawn at all times. 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, targetRange);
        if (currentTarget)
        {
            Gizmos.DrawLine(this.transform.position, currentTarget.transform.position);
        }
    }


    void FixedUpdate()
    {
        // staring is active it searches for the closest enemy that is withing range and fears that enemy for atleast one tick.
        if (staring)
        {
            timer -= Time.deltaTime;
            float distanceToEnemy = targetRange;
            if (FearCollector.GetComponent<Fearing>().residents.Count != 0)
            {
                currentTarget = null;
                foreach (GameObject resident in FearCollector.GetComponent<Fearing>().residents) 
                {

                    if (distanceToEnemy > Vector3.Distance(resident.transform.position, this.transform.position))
                    {
                        distanceToEnemy = Vector3.Distance(resident.transform.position, this.transform.position);
                        currentTarget = resident;
                    }

                }
            }
            else
            {
                currentTarget = null;
            }
        }else
        {
            currentTarget = null;
        }

        if(timer <= 0)
        {
            staring = false;
        }

        // face the barrel perfectly to the closest enemy
        if (currentTarget != null)
        {
            currentTarget.GetComponent<ResidentsFearBar>().fearBar.GetComponent<Fearhandler>().GetFearedBrother(this.GetComponent<Interaction>().fearamount);
            Vector3 heading = currentTarget.transform.position - this.transform.position;
            heading.y = 0f;                                                            // since you want to rotate the head realistic and not having a weird angle.
            Quaternion direction = Quaternion.LookRotation(heading);
            this.transform.rotation = direction;

        }
        else
        {
            this.transform.rotation = new Quaternion(0, 0, 0, 0); // stops facing anyone
        }

    }

    public void StartStare() { // method to trigger the staring
        staring = true;
        timer = 10f;
    }
}