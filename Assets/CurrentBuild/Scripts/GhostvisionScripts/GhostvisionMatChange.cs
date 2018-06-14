using UnityEngine;
using System.Collections;

public class GhostvisionMatChange : MonoBehaviour {
    public Material Mat1;
    public Material Mat2;

    bool onOff = false;
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (onOff)
            {
                onOff = false;
                rend.material = Mat1;
            }
            else
            {
                onOff = true;
                rend.material = Mat2;
            }
        }
    }
}
