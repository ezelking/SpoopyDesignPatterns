using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{
    public bool open;
    private AudioSource squeekSound;
    Transform Door;
    Transform LeftDoor;
    Transform RightDoor;

    UnityEngine.AI.NavMeshObstacle obstacle;
    public bool locked;
    public bool activated;
    
    void Start()
    {
        open = true;
        squeekSound = GetComponent<AudioSource>();
        if (this.transform.name == "SingleDoor")
        {
            Door = transform.Find("Door");
        }
        else if (this.transform.name == "DoubleDoor")
        {
            LeftDoor = transform.Find("LeftDoor");
            RightDoor = transform.Find("RightDoor");
        }
        obstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        locked = false;
    }
    
    void FixedUpdate()
    {
        if (this.transform.name == "SingleDoor")
        {
            if (!open && Door.localRotation.y > 0)
            {
                Door.Rotate(0, -1, 0);
            }
            else if (!open && Door.localRotation.y < 0)
            {
                Door.localEulerAngles = new Vector3(Door.localEulerAngles.x, 0f, Door.localEulerAngles.z);
                Lock();
                squeekSound.Stop();
            }
            if (open && Door.localRotation.y < 0.7)
            {
                Door.Rotate(0, 1, 0);
            }
            else if (open && Door.localRotation.y > 0.7)
            {
                Door.localEulerAngles = new Vector3(Door.localEulerAngles.x, 90f, Door.localEulerAngles.z);
                squeekSound.Stop();
            }
        }
        else if (this.transform.name == "DoubleDoor")
        {
            if (!open && LeftDoor.localRotation.y > 0)
            {
                LeftDoor.Rotate(0, -1, 0);
                RightDoor.Rotate(0, 1, 0);
            }
            else if (!open && LeftDoor.localRotation.y < 0)
            {
                LeftDoor.localEulerAngles = new Vector3(LeftDoor.localEulerAngles.x, 0f, LeftDoor.localEulerAngles.z);
                RightDoor.localEulerAngles = new Vector3(RightDoor.localEulerAngles.x, 0f, RightDoor.localEulerAngles.z);
                Lock();
                squeekSound.Stop();
            }
            if (open && LeftDoor.localRotation.y < 0.7)
            {
                LeftDoor.Rotate(0, 1, 0);
                RightDoor.Rotate(0, -1, 0);
            }
            else if (open && LeftDoor.localRotation.y > 0.7)
            {
                LeftDoor.localEulerAngles = new Vector3(LeftDoor.localEulerAngles.x, 90f, LeftDoor.localEulerAngles.z);
                RightDoor.localEulerAngles = new Vector3(RightDoor.localEulerAngles.x, -90f, RightDoor.localEulerAngles.z);
                squeekSound.Stop();
            }

            if (open)
            {
                locked = false;
            }
            obstacle.enabled = locked; // Makes it an obstacle for residents if locked.
        }
    }

    public void squeek()
    {
        squeekSound.Play();
    }

    public void Lock()
    {
        // Unlocks all doors then afterwards only locks this particular doors.
        for (int i = 0; i < transform.parent.parent.childCount; i++)
        {
            if (transform.parent.parent.GetChild(i).name.Contains("DoorInteraction") && transform.parent.parent.GetChild(i).GetChild(0).GetComponent<DoorScript>().locked) {
                transform.parent.parent.GetChild(i).GetChild(0).GetComponent<DoorScript>().open = true;
            }
        }
        locked = true;


    }
}