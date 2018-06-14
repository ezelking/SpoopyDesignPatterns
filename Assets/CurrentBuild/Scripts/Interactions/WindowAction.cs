using UnityEngine;
using System.Collections;

public class WindowAction : MonoBehaviour
{

    // Use this for initialization
    public float Rotation = 90;
    public int RepeatAmount = 11;
    public float RotationSpeed = 2.0f, AI_TimeAmount = 12.0f;
    public AudioSource audio;
    public AudioClip window;
    public bool activated = false, turning = false, ready = true, AI_Hit = false;
    Transform child;
    

    [SerializeField]
    private Vector3 BaseRotation;

    [SerializeField]
    private int RotateAmount = 0;

    [SerializeField]
    private float RotateTime;
    private float AI_Time;
    private bool AI_Timer = false;

    [SerializeField]
    private AreaTaunt _areaTaunt;


    public IEnumerator timer()
    {
        if (ready)
        {
            BaseRotation = this.transform.rotation.eulerAngles;

            for (int i = 0; i < RepeatAmount; i++)
            {
                //code for turning window
                turning = true;
                RotateAmount = i;

                audio.PlayOneShot(window);
                yield return new WaitForSeconds(RotateTime);
            }

            ready = false;
            _areaTaunt.TauntReady = true;
            turning = false;
            RotateAmount = 0;
        }
    }

    public void WindowInteraction()
    {
        StartCoroutine(timer());
    }

    void Start()
    {
        AI_Time = AI_TimeAmount;
        child = transform.Find("Window");
    }

    // Update is called once per frame
    void Update()
    {
        //handling activation
        if (activated == true)
        {
            WindowInteraction();
            activated = false;
            //GetComponent<residentMovement>().investigate(this.transform.position);
        }

        if (turning == true)
        {
            if (isOdd(RotateAmount))
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(new Vector3(0, BaseRotation.y + Rotation, 0)), RotateTime);
            }
            else
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(new Vector3(0, BaseRotation.y, 0)), RotateTime);
            }
        }

        if (AI_Timer)
        {
            AI_Time -= 1 * Time.deltaTime;
        }

        //reset with AI
        if (AI_Hit)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(new Vector3(0, BaseRotation.y, 0)), RotateTime);
            AI_Timer = true;
            if (AI_Time <= 0)//this.transform.rotation.eulerAngles == new Vector3(0, BaseRotation.y, 0))
            {
                ready = true;
                AI_Hit = false;
                AI_Timer = false;
                AI_Time = AI_TimeAmount;
            }
            
        }
    }

    public static bool isOdd(int num)
    {
        return num % 2 == 0;
    }

    void FixedUpdate()
    {
        if (activated == true)
        {
            //child.Rotate(0, 1, 0);
            //activated = false;
        }

        if (child.localRotation.y > 0.7)
        {
            child.localEulerAngles = new Vector3(child.localEulerAngles.x, 90f, child.localEulerAngles.z);
        }
    }
}
