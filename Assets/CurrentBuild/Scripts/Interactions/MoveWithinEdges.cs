using UnityEngine;
using System.Collections;

public class MoveWithinEdges : MonoBehaviour {
    public GameObject LawnMover;
   public  Vector3 heading;
   public Quaternion direction;

	// Use this for initialization
	void Start () {
      

    }
	
	
	void Update () { // Rotates and moves the lawn mower towards the center if it gets out of bounds 
        if (!checkif1isin2(LawnMover, this.gameObject) && LawnMover.GetComponent<LawnMowing>().mowing)
        {
            heading = this.GetComponent<Collider>().bounds.center - LawnMover.transform.position;
            heading.y = 0.2f;
            direction = Quaternion.LookRotation(heading);
            LawnMover.transform.rotation = Quaternion.RotateTowards(LawnMover.transform.rotation, direction, 5f);
            
        }
    }

    public bool checkif1isin2(GameObject sourceObject, GameObject targetObject) // altered method from fear collector.
    {
        if (sourceObject != null && targetObject != null)
        {
          
            Vector3 position = sourceObject.GetComponent<Collider>().bounds.center;
            Vector3 size2 = targetObject.GetComponent<Collider>().bounds.size;
            Vector3 position2 = targetObject.GetComponent<Collider>().bounds.center;
            if ((position.x ) < (position2.x + size2.x / 2f) && (position.x ) > (position2.x - size2.x / 2f))
            {

                if ((position.y) < (position2.y + size2.y / 2f) && (position.y) > (position2.y - size2.y / 2f))
                {

                    if ((position.z) < (position2.z + size2.z / 2f) && (position.z) > (position2.z - size2.z / 2f))
                    {
                        return true;
                    }
                }

            }


        }
        return false;
    }
}
