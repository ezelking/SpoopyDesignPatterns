﻿using UnityEngine;
using System.Collections;

public class SingleDoor : MonoBehaviour {

    UnityEngine.AI.NavMeshObstacle obstacle;
    public bool locked;
    public bool activated;

    void Awake()
    {
        obstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        locked = false;
    }

    void Update()
    {
        if (activated)
        {
            locked = !locked;
            if (locked)
            {
                obstacle.enabled = true;
            }
            if (!locked)
            {
                obstacle.enabled = false;
            }
            activated = false;
        }
    }
}
