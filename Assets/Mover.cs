using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float movementPerSecond = 1f;

    public int ballSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("My Name is " + gameObject.name);
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
            rbody.AddForce(force, ForceMode.VelocityChange);
            //transform.position += Vector3.right * movementAxis * movementPerSecond * Time.deltaTime;
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
        }
        // Hardcoded way for Up/Down movement of Paddle
        // When A is pressed
        // if (Input.GetKey(KeyCode.A))
        // {
        //     Transform transform = GetComponent<Transform>();
        //     transform.position += -Vector3.right * movementPerSecond * Time.deltaTime;
        // }
        // // When D is pressed
        // if (Input.GetKey(KeyCode.D))
        // {
        //     Transform transform = GetComponent<Transform>();
        //     transform.position += Vector3.right * movementPerSecond * Time.deltaTime;
        // }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball(Clone)")
        {
            if (gameObject.name == "L_Paddle")
            {
                // Debug.Log("Mover Name: " + gameObject.name);
                BoxCollider bbox = GetComponent<BoxCollider>();
                // Determining where center of bbox is
                float xCenter = bbox.bounds.center.x;
                // Debug.Log(gameObject.name + " Mover collided with " + collision.gameObject.name);
                // Debug.Log(gameObject.name + " Center at " + xCenter + ". Ball at " + collision.transform.position.x);
                // Debug.Log("Size of Paddle" + bbox.size);

                // Not a great magical number(1/2 of paddle X size in scale) but I need to figure out how to get Size of Collider right now it is just (1,1,1)
                float anglePercentage = (xCenter - collision.transform.position.x) / 2.5f;
                // Debug.Log("Percentage:" + anglePercentage);
                // Debug.Log("Percentage of 45 degrees " + anglePercentage * 45f);

                // To determine angle of reflection for ball
                // Rotation
                Vector3 newVector = Quaternion.Euler(0f, anglePercentage * 45f, 0f) * Vector3.back;
                Debug.DrawLine(transform.position, transform.position + newVector * 30f, Color.red);
                Rigidbody rbody = collision.gameObject.GetComponent<Rigidbody>();
                ballSpeed++;
                // Debug.Log("Ball speed:" + ballSpeed);
                rbody.velocity = newVector * ballSpeed;
                // Debug.Break();
            }
            else if (gameObject.name == "R_Paddle")
            {
                // Debug.Log("Mover Name: " + gameObject.name);
                BoxCollider bbox = GetComponent<BoxCollider>();
                // Determining where center of bbox is
                float xCenter = bbox.bounds.center.x;
                // Debug.Log(gameObject.name + " Mover collided with " + collision.gameObject.name);
                // Debug.Log(gameObject.name + " Center at " + xCenter + ". Ball at " + collision.transform.position.x);
                //Debug.Log("Size of Paddle" + bbox.size);
                // Not a great magical number(1/2 of paddle X size in scale) but I need to figure out how to get Size of Collider right now it is just (1,1,1)
                float anglePercentage = (xCenter - collision.transform.position.x) / 2.5f;
                // Debug.Log("Percentage:" + anglePercentage);
                // Debug.Log("Percentage of 45 degrees " + anglePercentage * 45f);

                // To determine angle of reflection for ball
                // Rotation

                Vector3 newVector = Quaternion.Euler(0f, -anglePercentage * 45f, 0f) * Vector3.forward;
                Debug.DrawLine(transform.position, transform.position + newVector * 30f, Color.red);
                Rigidbody rbody = collision.gameObject.GetComponent<Rigidbody>();
                ballSpeed++;
                // Debug.Log("Ball speed:" + ballSpeed);
                rbody.velocity = newVector * ballSpeed;
                //Debug.Break();
            }
        }
        //rbody.AddForce(newVector, ForceMode.Impulse);
        //Debug.Break();

        // Rigidbody rbody = instance.GetComponent<Rigidbody>();
        // float dirX = 10f;
        // float dirY = 0f;
        // float dirZ = 10f;
        // rbody.AddForce(dirX, dirY, dirZ, ForceMode.Impulse);
    }
}
