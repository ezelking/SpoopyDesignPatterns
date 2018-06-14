using UnityEngine;
using System.Collections;

public class MailBox : MonoBehaviour {
    //simple rotator for the mailbox model
    //note the rotating part is a model made in unity
    //another note only the rotating part rotates and is not directly attached in the model

    public bool Activated;

    //simple activates it upon raycast mouse hit
    public void Activate()
    {
        if(!Activated)
        {
            //rotates forth
            this.transform.Rotate(0f, 0f, 90f);
            Activated = true;
        }
        else if(Activated)
        {
            //rotates back
            this.transform.Rotate(0f, 0f, -90f);
            Activated = false;
        }
        //code to bring le residents
        //note this isn't made... sherlock
    }
}
