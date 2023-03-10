using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    //Mouse Delta controls camera
    public InputAction cameracontroller;

    //Right Click unlocks the camera
    public InputAction cameralock;

    //DO NOT TOUCH IN INSPECTOR!!
    //*************************
    public Vector2 look;
    public bool cameralocked;
    public float sensitivity;
    public float lookx;
    private float looky;
    private float rotationx;
    public float rotationy;
    //**************************


    public Transform playerposition;
    public Transform orientation;
    
    // Start is called before the first frame update
    void Start()
    {

        cameralocked = false;
    }

    void OnEnable() {
        cameracontroller.Enable();
        cameralock.Enable();
    }

    void OnDisable() {
        cameracontroller.Disable();
        cameralock.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        cameralocked = cameralock.IsPressed();
        transform.position = playerposition.transform.position;
        if (cameralocked == true) {
            Look();
        }
    }

    private void Look() {
        look = cameracontroller.ReadValue<Vector2>();

        lookx = look.x * sensitivity * Time.deltaTime;
        looky = look.y * sensitivity * Time.deltaTime;

        rotationx -= looky;
        rotationy += lookx;

        rotationx = Mathf.Clamp(rotationx,-45.0f,10.0f);
        transform.rotation = Quaternion.Euler(-rotationx,-rotationy,0);

        orientation.transform.Rotate(Vector3.up * lookx);

    }
}
