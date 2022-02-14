using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float movementPerSecond = 1f;
    // Audio clip is the variable type for any digital audio file
    public AudioClip ballPaddleSound;

    public static float ballSpeed = 10f;
    // Remember to Add Component -> Audio Source to game object with this script
    // Made public so that Goal Sensor can reset the pitch
    public static AudioSource source;

    private Vector3 scaleChange;

    // Start is called before the first frame update
    void Awake()
    {
        // Requirement 1 Get audio source component 
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.name == "L_Paddle")
        {
            // Using Input Manager to get Horizontal Axis for Up/Down movement of Paddle
            float movementAxis = Input.GetAxis("Horizontal");

            //Transform transform = GetComponent<Transform>();
            // Get Rigid Body Component
            Rigidbody rbody = GetComponent<Rigidbody>();

            // Add force to rigid body for movement
            Vector3 force = Vector3.right * movementAxis * movementPerSecond * Time.deltaTime;
            rbody.AddForce(force, ForceMode.Impulse);
            //transform.position += Vector3.right * movementAxis * movementPerSecond * Time.deltaTime;
            
            // Power Up 2 Paddle Size Change
            if (PowerUps.leftPowerUp2)
            {
                // Left grows in Size
                Transform transform = GetComponent<Transform>();
                scaleChange = new Vector3(10, 1, 1);
                transform.localScale = scaleChange;
                Invoke("resetPaddle", 10f);
            }
            else if (PowerUps.rightPowerUp2)
            {
                // Left Shrinks in Size
                Transform transform = GetComponent<Transform>();
                scaleChange = new Vector3(2, 1, 1);
                transform.localScale = scaleChange;
                Invoke("resetPaddle", 10f);
            }
        }
        else if (gameObject.name == "R_Paddle")
        {
            // Using Input Manager to get Horizontal Axis for Up/Down movement of Paddle
            float movementAxis_2 = Input.GetAxis("Horizontal_2");

            //Transform transform = GetComponent<Transform>();
            // Get Rigid Body Component
            Rigidbody rbody = GetComponent<Rigidbody>();

            // Add force to rigid body for movement
            Vector3 force = Vector3.right * movementAxis_2 * movementPerSecond * Time.deltaTime;
            rbody.AddForce(force, ForceMode.Impulse);
            
            // Power Up 2 Paddle Size Change
            if (PowerUps.leftPowerUp2)
            {
                // Right Shrinks in Size
                Transform transform = GetComponent<Transform>();
                scaleChange = new Vector3(2, 1, 1);
                transform.localScale = scaleChange;
                Invoke("resetPaddle", 10f);
            }
            else if (PowerUps.rightPowerUp2)
            {
                // Right grows in Size
                Transform transform = GetComponent<Transform>();
                scaleChange = new Vector3(10, 1, 1);
                transform.localScale = scaleChange;
                Invoke("resetPaddle", 10f);
            }
        }
    }

    void resetPaddle()
    {
        Transform transform = GetComponent<Transform>();
        scaleChange = new Vector3(5, 1, 1);
        transform.localScale = scaleChange;
        PowerUps.rightPowerUp2 = false;
        PowerUps.leftPowerUp2 = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //AudioSource source = GetComponent<AudioSource>();
        source.clip = ballPaddleSound;
        if (collision.gameObject.name == "Ball(Clone)")
        {
            if (gameObject.name == "L_Paddle")
            {
                BoxCollider bbox = GetComponent<BoxCollider>();
                // Determining where center of bbox is
                float xCenter = bbox.bounds.center.x;

                // Not a great magical number(1/2 of paddle X size in scale) but I need to figure out how to get Size of Collider right now it is just (1,1,1)
                float anglePercentage = (xCenter - collision.transform.position.x) / 2.5f;

                // To determine angle of reflection for ball
                // Rotation
                Vector3 newVector = Quaternion.Euler(0f, anglePercentage * 45f, 0f) * Vector3.back;
                Debug.DrawLine(transform.position, transform.position + newVector * 30f, Color.red);
                Rigidbody rbody = collision.gameObject.GetComponent<Rigidbody>();
                ballSpeed++;
                // Requirement 1 Increase ball pitch with every paddle strike (using input ballSpeed)
                source.pitch = ballSpeed / 10f;
                rbody.velocity = newVector * ballSpeed;
                // Debug.Break(); // Pause Game here
                PowerUps.leftWasLast = true;
            }
            else if (gameObject.name == "R_Paddle")
            {
                BoxCollider bbox = GetComponent<BoxCollider>();
                // Determining where center of bbox is
                float xCenter = bbox.bounds.center.x;
                // Not a great magical number(1/2 of paddle X size in scale) but I need to figure out how to get Size of Collider right now it is just (1,1,1)
                float anglePercentage = (xCenter - collision.transform.position.x) / 2.5f;

                // To determine angle of reflection for ball
                // Rotation
                Vector3 newVector = Quaternion.Euler(0f, -anglePercentage * 45f, 0f) * Vector3.forward;
                Debug.DrawLine(transform.position, transform.position + newVector * 30f, Color.red);
                Rigidbody rbody = collision.gameObject.GetComponent<Rigidbody>();
                ballSpeed++;
                // Requirement 1 Increase ball pitch with every paddle strike (using input ballSpeed)
                source.pitch = ballSpeed/10f;
                rbody.velocity = newVector * ballSpeed;
                //Debug.Break(); // Pause Game here
                PowerUps.leftWasLast = false;
            }
            // Play sound on ball/paddle collision
            //source.PlayOneShot(ballPaddleSound, 1F); // alternate method with volume control parameter
            source.Play();
        }
        // Play sound on ball/wall collision
    }
}
