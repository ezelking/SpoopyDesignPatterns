using UnityEngine;
using System.Collections;

public class NewBookcaseScript : MonoBehaviour
{
    public bool activated;
    public bool inCase;
    public GameObject bookPrefab;
    GameObject books;
    Transform[] bookTransforms;
    int resetTimer;
    
   private void Start()
    {
        activated = false;
        inCase = true;
        books = transform.Find("Books").gameObject;
        bookTransforms = new Transform[books.transform.childCount];
        Reset();
        // Saves the sizes and placement of all the books in the case.
        for (int i = 0; i < books.transform.childCount; i++)
        {
            bookTransforms[i] = books.transform.GetChild(i).transform;
        }
        resetTimer = 0;
    }
    
    void FixedUpdate()
    {
        if (activated && inCase)
        {
            // Pushes all the books in the case.
            for (int i = 0; i < books.transform.childCount; i++)
            {
                if (books.transform.GetChild(i).childCount > 0)
                {
                    books.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * Random.Range(100, 200));
                    activated = false;
                }
            }
            inCase = false;
        }
        if (!inCase)
        {
            resetTimer++;

            if (resetTimer > 50)
            {
                GetComponent<Interaction>().fearingOn = false;
            }

            if (resetTimer > 200)
            {
                Reset();
            }
        }
    }

    // Replaces the old books for new books.
    void Reset()
    {
        for (int i = 0; i < books.transform.childCount; i++)
        {
            GameObject book = ObjectPooler.SharedInstance.GetPooledObject();
            if (book != null)
            {
                book.transform.parent = books.transform.GetChild(i);
                book.transform.localPosition = new Vector3(0, 0, 0);
                book.transform.localRotation = new Quaternion(0, 0, 0, 0);
                book.transform.localScale = new Vector3(1, 1, 1);
            }
            
        }
        activated = false;
        inCase = true;
        resetTimer = 0;
    }
}
