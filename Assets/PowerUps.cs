using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public static bool leftWasLast = false;
	
	public static bool leftPowerUp1 = false;
	public static bool leftPowerUp2 = false;
	public static bool rightPowerUp1 = false;
	public static bool rightPowerUp2 = false;
	// Small Juicy addition: Spin the power ups
	private float rotationSpeed = 500f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// Small Juicy addition: Spin the power ups
        Transform transform = GetComponent<Transform>();
        transform.Rotate(Vector3.right * (rotationSpeed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider collider)
    {
		// If Left was last give Left the Power Up
		if(leftWasLast){
			// If Power Up 1 was activated
			if(this.name == "PowerUp_1"){
				leftPowerUp1 = true;
			}
			// If Power Up 2 was activated 
			if(this.name == "PowerUp_2"){
				leftPowerUp2 = true;
			}
		}
		// If Right was last give Right the Power Up
		if(!leftWasLast){
			// If Power Up 1 was activated
			if(this.name == "PowerUp_1"){
				rightPowerUp1 = true;
			}
			// If Power Up 2 was activated 
			if(this.name == "PowerUp_2"){
				rightPowerUp2 = true;
			}
		}

    }
}
