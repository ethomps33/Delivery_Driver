using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    //varibale for the turning speed of the car
    [SerializeField] float steerSpeed = 225f; 
    //variable for the forward and backward speed of the car
    [SerializeField] float moveSpeed = 30f;
    // [SerializeField] float speed = moveSpeed;
    //variable for the speed after driving over a speedup
    [SerializeField] float fastSpeed = 5f;
    //variabel for the speed after driving over a slowdown
    [SerializeField] float slowSpeed = -5f;
    
    // GameObject customer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //reference to the Delivery class
        Delivery dp = gameObject.GetComponent<Delivery>();
        //variable to control the speed of the car on the vertical axis normalizing for the framerate of different systems
        float forwardAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //variable to control the speed of the car on the horizonatal axis normalizing for the framerate of different systems
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        //placing variable in the area that needs to change to affect the vertical speed
        transform.Translate(0, forwardAmount, 0);
        //placign the variable in the area that needs to change to affect the horizontal speed
        transform.Rotate(0, 0, -steerAmount);



    //     float threeSpeed = -5f;
    //     float fourSpeed = -15f;
    //     //switch statement to change the vertical speed of the car based on how many packages the car currently; 
    //     //using object reference from Delivery class
    //     switch (dp.count)
    //     {
    //         case 0:
    //         case 1:
    //         case 2:
    //         break;
    //         case 3:
    //         moveSpeed = moveSpeed + threeSpeed;
    //         break;
    //         case 4:
    //         moveSpeed = moveSpeed + fourSpeed;
    //         break;
    //         case 5:
    //         moveSpeed = 0;
    //         break;
    //         default:
    //         moveSpeed = 30;
    //         break;
    //     } 
    // }

    // slows down the car if it runs into anything
    // void OnCollisionEnter2D(Collision2D other) 
    // {
    //     // if (other.tag == "WorldObject") {
    //         moveSpeed = slowSpeed + moveSpeed;
    //         Debug.Log("Welp, the insruance is gonna go up now.");
    //     // }
    // }

    void OnTriggerEnter2D(Collider2D other) {
         //if the tag of the gameobject is Boost the car's speed will increase
        if (other.tag == "Boost") {
            moveSpeed = fastSpeed + moveSpeed;
            Destroy(other.gameObject);
            Debug.Log("Ya Hooooooo!!");
        }

        //if the tag go the gameobject is SlowDown the car's speed will decrease
        else if (other.tag == "SlowDown") {
            moveSpeed = slowSpeed + moveSpeed;
            Destroy(other.gameObject);
            Debug.Log("Yuck! ran over some sticky tar!");
        }
    }
}
