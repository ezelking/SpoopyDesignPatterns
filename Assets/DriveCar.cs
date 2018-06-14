using UnityEngine;
using System.Collections;

public class DriveCar : MonoBehaviour {
    public bool drivingCar;
    public float timer;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (drivingCar) {

            timer -= Time.deltaTime;
            transform.Rotate(Vector3.up * Time.deltaTime * 90);

        }
        if(timer<= 0)
        {
            this.transform.GetChild(0).GetComponent<Interaction>().fearingOn = false;
            drivingCar = false;
        }
	}

    public void Drive() {
        drivingCar = true;
        timer = 5f;
    }

}
