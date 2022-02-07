using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSensor : MonoBehaviour
{
    public int pointsToWin = 11;
    private static int leftPoints = 0;
    private static int rightPoints = 0;

    public static int lastScored = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider collider)
    {
        // When ball enters a goal
        // Debug.Log("Collider " + collider.name + " Entered goal " + this.name);
        // If Right scores on Left
        if (this.name == "L_Goal")
        {
            rightPoints++;
            lastScored = 1;
            Debug.Log("Right Paddle scored!");
            Debug.Log("Current Score - Left Paddle: " + leftPoints + " Right Paddle: " + rightPoints);
            // If it was game point
            if (rightPoints == pointsToWin)
            {
                Debug.Log("Game Over");
                Debug.Log("Final Score - Left Paddle: " + leftPoints + " Right Paddle: " + rightPoints);
                Debug.Log("Right Paddle Wins!");
                // gameStarted = false;
                rightPoints = 0;
                leftPoints = 0;
            }
			BallSpawn.gameStart = false;

        }
        // If Left scores on Right
        else if (this.name == "R_Goal")
        {
            leftPoints++;
            lastScored = 0;
            Debug.Log("Left Paddle scored!");
            Debug.Log("Current Score - Left Paddle: " + leftPoints + " Right Paddle: " + rightPoints);
            // If it was game point
            if (leftPoints == pointsToWin)
            {
                Debug.Log("Game Over");
                Debug.Log("Final Score - Left Paddle: " + leftPoints + " Right Paddle: " + rightPoints);
                Debug.Log("Left Paddle Wins!");
                // gameStarted = false;
                rightPoints = 0;
                leftPoints = 0;
            }
			BallSpawn.gameStart = false;
        }
        Destroy(collider.gameObject);
    }
}
