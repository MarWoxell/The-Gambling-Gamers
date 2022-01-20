using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraControll : MonoBehaviour
{
    //Script by Elio
    public float mouseSensitivity = 250f;
    public Transform cameraTransform;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Locks the cursor in the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //gives mouseX and mouseY a value that will be used for the camera movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //Left and right
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Oscar"))
        {
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //Up and down
            xRotation -= mouseY;
        }

        //Moves the camera on the x and y position
        transform.Rotate(Vector3.up * mouseX);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0f);
        //Makes it so that uou can't look up or down over 90 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}
