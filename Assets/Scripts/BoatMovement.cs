using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoatMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Camera mainCam;

    private float leftLaneX = -1.65f;
    private float rightLaneX = 1.65f;

    private Vector2 targetPosition;


    void Start()
    {
        // Set the initial position of the car which is determined by where we put it in Unity Editor
        targetPosition = new Vector2(transform.position.x, transform.position.y);
    }


    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
    }

    private void Update() {

        //when car is not moving side to side ( taying either in the left lane or right lane), set rotation to 0 so that the car is facing forward
        if (transform.position.x == leftLaneX || transform.position.x == rightLaneX) {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        

        //checks space bar input
        if (Input.GetKey(KeyCode.Space)) {
            SwitchLane();
        }


        //tells the car to move towards the given position which we got from the SwitchLane() method (either go right lane or left lane)
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 10f);
        

    }

    void SwitchLane () {
        if (Mathf.Abs(transform.position.x - leftLaneX) < 0.1f) {
            // If in left lane, set the target position where car needs to go, to the right lane
            targetPosition = new Vector2(rightLaneX, transform.position.y);
            transform.rotation = Quaternion.Euler(0,0,-30);
            
        } else if (Mathf.Abs(transform.position.x - rightLaneX) < 0.1f){
            // If in right lane, set the target position where car needs to go, to the left lane
            targetPosition = new Vector2(leftLaneX, transform.position.y);
            transform.rotation = Quaternion.Euler(0,0,30);
            
        }
    }
}
