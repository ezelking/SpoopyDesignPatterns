using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BookCaseScript : MonoBehaviour {

    public bool activated = false, RespawnTimer = false;
    public float RTime = 0, RespawnTime = 10;
    public GameObject book;
    public List<GameObject> Books = new List<GameObject>();
    public List<GameObject> Spawns = new List<GameObject>();
    [SerializeField]
    private Vector3 BaseRotation;

	// Use this for initialization
	void Start ()
    {
        
        BaseRotation = this.transform.rotation.eulerAngles;
        HandleBookSpawn();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //handling activation for testing
        if (activated == true)
        {
            BookCaseInteraction();
            activated = false;
        }
 
        if (RespawnTimer)
        {
            RTime += Time.deltaTime;
        }

        if(RTime >= RespawnTime)
        {
            RespawnTimer = false;
            BookReset();
            RTime = 0;

            //HandleBookSpawn();
        }

        if(RTime >= 2)
        {
            GetComponent<Interaction>().fearingOn = false;

        }
        Debug.DrawLine(transform.position, (transform.position + Vector3.forward * 3));
    }

    void BookCaseInteraction()
    {

        if (!RespawnTimer)
        {
            foreach (var book in Books)
            {
                //give each book a boost
                book.GetComponent<Rigidbody>().AddForce(transform.right, ForceMode.Impulse);
            }

            RespawnTimer = true;
        }
    }

    void HandleBookSpawn()
    {
        /*for(int i = 0; i < Spawns.Count-1; i++)
        {
            GameObject bookz = (GameObject)Instantiate(book);
            //spawn each book at the right position and angle in the bookcase
            bookz.transform.position = Spawns[i].transform.position;
            bookz.transform.rotation = this.transform.rotation;
            bookz.transform.parent = Spawns[i].transform;

            //Debug.Log(bookz.transform.position);
            Books.Add(bookz);
            
        }*/
    }

    void BookReset()
    {
        for (int i = 0; i < Spawns.Count; i++)
        {
            //replace the books on top of the bookcase
            Books[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            Books[i].transform.position = Spawns[i].transform.position;
            Books[i].transform.rotation = this.transform.rotation;


        }
    }
}
