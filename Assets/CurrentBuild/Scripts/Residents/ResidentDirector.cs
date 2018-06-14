using UnityEngine;
using System.Collections;

public class ResidentDirector : MonoBehaviour {

    public GameObject[] kitchenWPs;
    public GameObject[] diningRoomWPs;
    public GameObject[] livingRoomWPs;
    public GameObject[] firstFHallWPs;
    public GameObject[] masterBedroomWPs;
    public GameObject[] officeWPs;
    public GameObject[] bathroomWPs;
    public GameObject[] toilerWPs;
    public GameObject[] southBedroomWPs;
    public GameObject[] northBedroomWPs;

    public GameObject[] enSuiteWPs;
    public GameObject[] libraryWPs;


    // Use this for initialization
    void Start()
    {

        kitchenWPs = GameObject.FindGameObjectsWithTag("KitchenWP");
        diningRoomWPs = GameObject.FindGameObjectsWithTag("DiningRoomWP");
        livingRoomWPs = GameObject.FindGameObjectsWithTag("LivingRoomWP");
        firstFHallWPs = GameObject.FindGameObjectsWithTag("1fHallWP");
        masterBedroomWPs = GameObject.FindGameObjectsWithTag("MasterBedroomWP");
        officeWPs = GameObject.FindGameObjectsWithTag("OfficeWP");
        bathroomWPs = GameObject.FindGameObjectsWithTag("BathroomWP");
        toilerWPs = GameObject.FindGameObjectsWithTag("ToiletWP");
        southBedroomWPs = GameObject.FindGameObjectsWithTag("SouthBedroomWP");
        northBedroomWPs = GameObject.FindGameObjectsWithTag("NorthBedroomWP");

        enSuiteWPs = GameObject.FindGameObjectsWithTag("MasterBedroomWP");
        libraryWPs = GameObject.FindGameObjectsWithTag("OfficeWP");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
