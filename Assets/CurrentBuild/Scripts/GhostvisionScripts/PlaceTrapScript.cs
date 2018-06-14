using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaceTrapScript : MonoBehaviour {
    public GameObject bearTrap;
    public GameObject player;
    //UI skill icon
    public Image trapOffIcon;

    private bool onCooldown;

    private float cooldownCounter;
    public float cooldownTime = 5;

    void Start () {
        onCooldown = false;
        cooldownCounter = 0;
    }
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!onCooldown)
            {
                // places beartrap prefab (added in inspector) a little infront of the player
                Instantiate(bearTrap, player.transform.position + (player.transform.forward * 2), transform.rotation);
                //TrapOffIcon.fill will continously go down whilst > 0, function as Countdown timer
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
