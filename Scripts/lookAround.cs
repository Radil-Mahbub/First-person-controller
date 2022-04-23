using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAround : MonoBehaviour
{
    public int mouseSensittivity = 100;
    public Transform playerBody;

    float xRotate = 0f;

    // Start is called before the start of the game
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        //takes in data from the mouse to move on the X and Y axis
        float mouseX = Input.GetAxis("Mouse X") * mouseSensittivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensittivity * Time.deltaTime;

        //makes sure you cant look behind yourself while
        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
