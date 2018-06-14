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

    void OnDrawGizmos()
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
            heading.y = 0f;                                                            // since you want to point to the center of the object not the top.  
            Quaternion direction = Quaternion.LookRotation(heading);
            this.transform.rotation = direction;

        }
        else
        {
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

    }

    public void StartStare() {
        staring = true;
        timer = 10f;
    }
}