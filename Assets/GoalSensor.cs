using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoalSensor : MonoBehaviour
{
    public int pointsToWin = 11;
    private static int leftPoints = 0;
    private static int rightPoints = 0;

    public static int lastScored = 0;

    // For manipulating Text gameObject
    public TextMeshProUGUI scoreText;
    
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
        // If Right scores on Left
        if (this.name == "L_Goal")
        {
            rightPoints++;
            lastScored = 1;
            // If Left is ahead
            if (leftPoints > rightPoints)
            {
                // Update Text Mesh Pro GUI based on the score 
                scoreText.text = "<color=green>" + leftPoints + "</color>   <color=red>" + rightPoints + "</color>";
            }
            // If Right is ahead
            else if(rightPoints > leftPoints) {
                // Update Text Mesh Pro GUI based on the score 
                scoreText.text = "<color=red>" + leftPoints + "</color>   <color=green>" + rightPoints + "</color>";
            }
            // If tied
            else {
                // Update Text Mesh Pro GUI based on the score 
                scoreText.text = "<color=yellow>" + leftPoints + "</color>   <color=yellow>" + rightPoints + "</color>";
            }
            // If it was game point
            if (rightPoints == pointsToWin)
            {
                // Update Text Mesh Pro GUI based on the score 
                scoreText.text = "<color=red>" + leftPoints + "</color>   <color=green>" + rightPoints + "</color><br>" +
                    "<color=green>Right Paddle Wins!</color>";
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
            // If Left is ahead
            if (leftPoints > rightPoints)
            {
                // Update Text Mesh Pro GUI based on the score 
                scoreText.text = "<color=green>" + leftPoints + "</color>   <color=red>" + rightPoints + "</color>";
            }
            // If Right is ahead
            else if (rightPoints > leftPoints)
            {
                // Update Text Mesh Pro GUI based on the score 
                scoreText.text = "<color=red>" + leftPoints + "</color>   <color=green>" + rightPoints + "</color>";
            }
            // If tied
            else
            {
                // Update Text Mesh Pro GUI based on the score 
                scoreText.text = "<color=yellow>" + leftPoints + "</color>   <color=yellow>" + rightPoints + "</color>";
            }

            // If it was game point
            if (leftPoints == pointsToWin)
            {
                scoreText.text = "<color=green>" + leftPoints + "</color>   <color=red>" + rightPoints + "</color><br>" +
                    "<color=green>Left Paddle Wins!</color>";

                rightPoints = 0;
                leftPoints = 0;
            }
			BallSpawn.gameStart = false;
        }
        Mover.ballSpeed = 10f;
        Destroy(collider.gameObject);
        Mover.source.pitch = 1F;
    }
}
