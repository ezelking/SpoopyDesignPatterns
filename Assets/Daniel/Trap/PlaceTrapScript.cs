using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaceTrapScript : MonoBehaviour {
    public GameObject bearTrap;
    public GameObject player;

    public Image trapOffIcon;

    private bool onCooldown;

    private float cooldownCounter;
    public float cooldownTime = 5;
	// Use this for initialization
	void Start () {
        onCooldown = false;
        cooldownCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!onCooldown)
            {
                Instantiate(bearTrap, player.transform.position + (player.transform.forward * 2), transform.rotation);
                trapOffIcon.fillAmount = 1;
                onCooldown = true;
            }
        }

        if (onCooldown)
        {
            cooldownCounter += Time.deltaTime;
            if (cooldownCounter >= cooldownTime)
            {
                cooldownCounter = 0;
                onCooldown = false;
            }
        }
    }

}
