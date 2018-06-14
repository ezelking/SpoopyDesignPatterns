using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Interaction : MonoBehaviour {

    public bool fearingOn = false;
    public int fearamount = 1;


    // interaction method for each interaction
    // just add the name of the interaction (the object that has the an activation script and this script) followed by interaction to the list below to use the interaction.
    public void SinkInteraction()
    {
        
        this.GetComponentInParent<waterTapScript>().Play();
        fearingOn = !fearingOn;
    }

    public void TVInteraction()
    {
       
        this.GetComponentInParent<TVScript>().Play();
        fearingOn = !fearingOn;
    }

    public void ChandelierInteraction()
    {
        this.GetComponent<chandelierCrash>().isFalling = true;
        fearingOn = true;
    }

    public void PianoInteraction()
    {
        this.GetComponentInParent<PianoPlay>().Play();
        fearingOn = !fearingOn;
    }

    public void VaseInteraction()
    {
        this.GetComponentInParent<VaseScript>().Push();
        fearingOn = true;
    }

    public void DoorInteraction()
    {
        Debug.Log(this.transform.parent.transform.parent.transform.parent.transform.GetChild(0).name);
        Debug.Log(this.transform.parent.transform.parent.transform.GetChild(0).name);
        if (this.transform.parent.transform.parent.transform.GetChild(0).name != "SingleDoor")
        {
                this.transform.parent.transform.parent.transform.parent.transform.GetChild(0).GetComponent<DoorScript>().open = !this.transform.parent.transform.parent.transform.parent.transform.GetChild(0).GetComponent<DoorScript>().open;
                this.transform.parent.transform.parent.transform.parent.transform.GetChild(0).GetComponent<DoorScript>().squeek();
            
        }
        else
        {
                this.transform.parent.transform.parent.transform.GetChild(0).GetComponent<DoorScript>().open = !this.transform.parent.transform.parent.transform.GetChild(0).GetComponent<DoorScript>().open;
                this.transform.parent.transform.parent.transform.GetChild(0).GetComponent<DoorScript>().squeek();
            
        }
    }

    public void BookcaseInteraction()
    {
        this.GetComponent<NewBookcaseScript>().activated = true;
        fearingOn = true;
    }

    public void WindowInteraction()
    {
        this.GetComponent<HandleWindow>().ExecuteWindow();
    }

    public void DoorBellInteraction()
    {
        AudioSource doorBellAudio = GetComponent<AudioSource>();
        doorBellAudio.Play();
    }


    public void SpiegelInteraction()
    {
        this.GetComponentInParent<spiegelActive>().Break();
        fearingOn = true;
    }

    public void SprinklerInteraction()
    {
        this.GetComponentInParent<SprinklerSprinkels>().Sprinkel();
        fearingOn = true;
    }  

    public void CarInteraction()
    {
        fearingOn = true;
        this.GetComponentInParent<DriveCar>().Drive();
    }

    public void LawnMowerInteraction()
    {
        fearingOn = true;
        this.GetComponentInParent<LawnMowing>().MowingMower();
    }

    public void StatueInteraction()
    {
        this.GetComponent<StareDownResident>().StartStare();
    }

    // locking doors
    public void DoorLock()
    {
        this.transform.parent.transform.parent.transform.parent.transform.GetChild(0).GetComponent<LockDoor>().activated = true;
    }

    // old candle activation still being called sometimes so it stays to avoid errors.
    
    public void CandleInteraction()
    { 
       
    }
}
