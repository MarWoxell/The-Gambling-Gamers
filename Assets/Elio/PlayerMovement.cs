using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Scribt by Elio
    public CharacterController playerController;
    public StaminaSlider stamina;
    Vector3 playerVector;
    float gravity = -9.82f;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = 12f;
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


        //Makes it so that you can sprint if you press down shift
        if (Input.GetKey(KeyCode.LeftShift) && stamina.outOfStamina == false)
        {
            //Depletes stamina when you sprint and changes the stamina bar
            speed = 18;
            stamina.stamina -= 0.75f;
            stamina.SetStamina(stamina.stamina);
        }
        else
        {
            //Regains stamina when you don't sprint at half the speed compared to the stamina depletion, also changes the stamina bar
            speed = 12;
            stamina.stamina += 0.375f;
            stamina.SetStamina(stamina.stamina);
        }
    }
}
