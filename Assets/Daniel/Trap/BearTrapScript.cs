using UnityEngine;
using System.Collections;

public class BearTrapScript : MonoBehaviour {
    private float effectTimer;
    public float effectDuration = 5;

    public ParticleSystem particles;

    GameObject target;
    private bool triggered;
	// Use this for initialization
	void Start () {
        effectTimer = 0;
        triggered = false;
        particles.Pause();
	}
	
	// Update is called once per frame
	void Update () {
        if (triggered)
        {
            effectTimer += Time.deltaTime;
            target.GetComponent<UnityEngine.AI.NavMeshAgent>().Stop();
            if (effectTimer >= effectDuration)
            {
                if (target != null)
                {
                    target.GetComponent<UnityEngine.AI.NavMeshAgent>().Resume();
                }
                Destroy(gameObject);
                effectTimer = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (triggered == false)
        {
            if (other.tag == "Resident")
            {
                particles.Play();
                target = other.gameObject;
                triggered = true;
            }
        }
    }
}
