using UnityEngine;
using System.Collections;

public class RayCastInteraction : MonoBehaviour
{
    public int range;
    public GameObject[] highlights;

    void Start()
    {


        highlights = GameObject.FindGameObjectsWithTag("Highlight");
        Screen.lockCursor = true;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {

        foreach (GameObject highlightarea in highlights)
        {
            if (highlightarea != null)
            {
                highlightarea.SetActive(false);
            }
        }

    }
    void Update()
    {


        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit, range);
        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.gameObject.layer == 11) // layer 11 = interaction layer
            {

                hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                // after hitting a object in the interaction layer it tries to find the method that is his name plus interaction inside the interaction script.
                if (Input.GetMouseButtonUp(0))
                {
                    hit.collider.gameObject.GetComponent<IInteractable>().Interact();
                    hit.collider.gameObject.GetComponent<IFearing>().ToggleFearing();
                }


            }
        }
    }
}
