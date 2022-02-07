using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform[] spawnTransforms;
    public float ballMovementPerSecond = 1f;
    public int alternate = 0;
    public static bool gameStart = false;
	public bool multiBall = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Press space to start the game
        if (Input.GetKeyDown(KeyCode.Space))
        {
			if(!gameStart){
            	// Starting ball spawn at random point
                int last = GoalSensor.lastScored;
                Transform startPointTransform = spawnTransforms[last];
                // Make new game object of ball prefab
                GameObject instance = Instantiate(ballPrefab);
                // Set ball position to random start position
                instance.transform.position = startPointTransform.position;
                // Add force to rigid body for movement
                // Get Rigid Body Component
                Rigidbody rbody = instance.GetComponent<Rigidbody>();
                if (last == 1)
                {
                    float dirX = 10f;
                    float dirY = 0f;
                    float dirZ = 10f;
                    rbody.AddForce(dirX, dirY, dirZ, ForceMode.VelocityChange);
                }
                else if (last == 0)
                {
                    float dirX = -10f;
                    float dirY = 0f;
                    float dirZ = -10f;
                    rbody.AddForce(dirX, dirY, dirZ, ForceMode.VelocityChange);
                }
				if(!multiBall){
                	gameStart = true;
				}
			}
        }
		// Turn Multiball mode On/Off with M Key
		if (Input.GetKeyDown(KeyCode.M))
        {
			if (multiBall){
				Debug.Log("Multiball Mode turned ON");
				multiBall = false;
			}
			else if (!multiBall){
				Debug.Log("Multiball Mode turned OFF");
				multiBall = true;
			}
		}
    }
    
}
