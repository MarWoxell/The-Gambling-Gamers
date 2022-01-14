using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Scribt by Elio
    public CharacterController playerController;
    Vector3 playerVector;
    float gravity = -9.82f;
    public float speed = 12f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gives x and z the horizontal and vertical value
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Creates gravity
        playerVector.y += gravity * Time.deltaTime;

        //Decides direction that player moves based on where the player looks
        Vector3 movement = transform.right * x + transform.forward * z;

        //Moves player based by speed and direction and velocity
        playerController.Move(movement * speed * Time.deltaTime);
        playerController.Move(playerVector * Time.deltaTime);
    }
}
