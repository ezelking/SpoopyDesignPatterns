using UnityEngine;
using System.Collections;

public class BearTrapScript : MonoBehaviour {
    private float effectTimer;
    // Duration of the Traps Stopping effect
    public float effectDuration = 5;
    // particles that will play when trap is triggered
    public ParticleSystem particles;
    //The Resident triggering the effect assigned in OntriggerEnter
    GameObject target;
    // Used to check if trap has been activated
    private bool triggered;

	void Start () {
        effectTimer = 0;
        triggered = false;
        particles.Pause();
	}
	

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
