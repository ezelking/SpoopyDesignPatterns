using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class residentMovement : MonoBehaviour
{


    /* 
    Add the names of all rooms the resident can roam into roomNames string array.
    Omit rooms the character does NOT roam in.
    A room name can be entered multiple times to make the resident more likely to roam there (a favorited room).
    Each room name must have corresponding Waypoints (empty game objects) with "roomName"+"WP" (example "KitchenWP"). CASE SENSITIVE!!
    */
    public string[] roomNames = new string[] { "Kitchen", "DiningRoom", "LivingRoom", "MasterBedroom", "Office", "Bathroom", "Toilet", "SouthBedroom", "NorthBedroom", "Ensuite", "Library" };


    //agent determines destination, speed, stopping distance etc.
    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent agent;

    // used for the investigation method
    float searchingTurnSpeed = 120f;
    private float searchDuration = 4f; // time spend searching location before returning to roaming state.
    private float searchTimer = 0;


    // for room alocation
    public float newRoomInterval = 5; // change to move between rooms faster
    private float newRoomCount = 0f;


    public string currentState;
    public string startingRoom = "Kitchen";

    Vector3 currentInvestigation;
    System.Action currentCallBack;


    //Actions variables
    private float actionTimer = 0f; // timer that counts action duration
    private float scareTimer = 0f;  // timer counts time to stop hiding
    private float destroyTimer = 0; // timer before making fleeing resident disappear

    // Scare From Player
    public GameObject residentSanctuary;
    public GameObject ghost;
    public GameObject killSpot;

    public GameObject thisCharacter;

    // Room assignment variables
    [HideInInspector]
    public GameObject[] currentRoomWPs;
    [HideInInspector]
    public string currentRoom;
    [HideInInspector]
    public string targetRoom;
    [HideInInspector]
    public GameObject targetWaypoint;


    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();


        currentRoom = startingRoom;
        targetRoom = currentRoom;
        currentRoomWPs = GameObject.FindGameObjectsWithTag(startingRoom + "WP");
        SetNewDestination();


        // resident will start in roaming state. 
        currentState = "roaming";
    }





    void Update()
    {
        if (currentState == "roaming")
        {
            Roaming();
        }
        if (currentState == "investigate")
        {
            investigate(currentInvestigation);
        }




        if (currentState == "scared")
        {
            FleeToSanctuary();
        }
    }



//Character moves to points in CurrentRoomWPs and performAction at named ones. If Currentroom differs from Targetroom, the new WPs will be loaded into currentRoomWPs.
    public void Roaming()
    {
        currentState = "roaming";
        if (targetRoom != currentRoom)
        {
            currentRoomWPs = GameObject.FindGameObjectsWithTag(targetRoom + "WP");
            currentRoom = targetRoom;
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            performAction(targetWaypoint.name);
        }


        if (newRoomCount >= newRoomInterval)
        {
            NewRandomRoom();
        }

    }




    //Resident moves to designated location, spins round for few seconds, then continues roaming
    public void investigate(Vector3 targetPosition)
    {
        if (this.tag == "Resident")
        {
            this.GetComponent<FacesScript>().ChangeFace("curious");
        }

        currentInvestigation = targetPosition;
       
        currentState = "investigate";


        agent.SetDestination(targetPosition);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            this.transform.Rotate(0, searchingTurnSpeed * Time.deltaTime, 0);
            searchTimer += Time.deltaTime;


            if (searchTimer >= searchDuration)
            {
                currentState = "roaming";
                Roaming();
                searchTimer = 0f;
                if (this.tag == "Resident")
                {
                    this.GetComponent<FacesScript>().ChangeFace("startled");
                }
            }
        }
    }




    // make character go to location
    public void goToTarget(Vector3 targetPosition)
    {
        agent.SetDestination(targetPosition);
    }


    // sets a new random room for roaming on a timed interval.
    public void NewRandomRoom()
    {
        newRoomInterval = Random.Range(3, 10);
        targetRoom = roomNames[Random.Range(0, roomNames.Length)];
        newRoomCount = 0f;
    }

    // Look for new waypoint in currentrooms array.
    public void SetNewDestination()
    {
        GameObject newTargetWaypoint = currentRoomWPs[Random.Range(0, currentRoomWPs.Length)];
        if (newTargetWaypoint != targetWaypoint)
        {
            targetWaypoint = newTargetWaypoint;
            Vector3 newTarget = targetWaypoint.transform.position;
            agent.SetDestination(newTarget);
        }


    }

    // perform action based on the target WPs name, Duration and actions can be customized per WP name. If name of WP is unknown, char will just set new destination without timer.
    public void performAction(string actionName)
    {
        switch (actionName)
        {
            case "Sink":
                actionTimer += Time.deltaTime;
                if (actionTimer >= 5)
                {
                    SetNewDestination();
                    actionTimer = 0;
                }
                break;
            case "Seat":
                actionTimer += Time.deltaTime;
                if (actionTimer >= 5)
                {
                    SetNewDestination();
                    actionTimer = 0;
                }
                break;
            case "Inspect":
                actionTimer += Time.deltaTime;
                if (actionTimer >= 5)
                {
                    SetNewDestination();
                    actionTimer = 0;
                }
                break;
            case "Countertop":
                actionTimer += Time.deltaTime;
                if (actionTimer >= 5)
                {
                    SetNewDestination();
                    actionTimer = 0;
                }
                break;
            case "Toilet":
                actionTimer += Time.deltaTime;
                if (actionTimer >= 15)
                {
                    SetNewDestination();
                    actionTimer = 0;
                }
                break;
            default:
                SetNewDestination();
                break;




        }


        newRoomCount += 1;
    }

// Character runs to point "killSpot" and be set to inactive.
    public void FleeFromHouse()
    {
        currentState = "GTFO";
        if (this.tag == "Resident")
        {
            this.GetComponent<FacesScript>().ChangeFace("GTFO");
        }

        agent.SetDestination(killSpot.transform.position);
        agent.speed = 12;
        destroyTimer += Time.deltaTime;
        if(agent.remainingDistance <= agent.stoppingDistance && destroyTimer >= 3)
        {
            destroyTimer = 0f;
            thisCharacter.SetActive(false);
        }
    }


    /*
    public void FleeFromPoint(Vector3 scarePoint)
    {
        currentState = "flee";
        scareTimer += Time.deltaTime;


        float minDistance = 5;
        float runSpeed = 6;


        if (Vector3.Distance(scarePoint, this.transform.position) > minDistance)
        {   
            Vector3 direction = this.transform.position - scarePoint;
            direction.Normalize();
            this.transform.position = Vector3.MoveTowards(this.transform.position, direction * minDistance, Time.deltaTime * runSpeed);
        }


        if (scareTimer > 5)
        {
            currentState = "roaming";
            scareTimer = 0;
        }
    }
    */

// Character hides in their favorite hiding spot aka "residentSanctuary"
    public void FleeToSanctuary()
    {
        currentState = "scared";
        agent.destination = residentSanctuary.transform.position;
        agent.speed = 10;
        scareTimer += Time.deltaTime;
        if (scareTimer > 15)
        {
            currentState = "roaming";
            agent.speed = 6;
            scareTimer = 0;
        }


    }

}




