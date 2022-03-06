using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private CameraMovement cam;
    private Rigidbody myRb;
    private void Awake() 
    {
        myRb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {
        MovementCharacter(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        RotateCharacter(Input.GetAxis("Vertical"), Input.GetAxis("Mouse X"));
    }
    void MovementCharacter(float x, float z)
    {
        Vector3 direction;
        direction = new Vector3(x, 0, z);
        transform.Translate(direction * speed * Time.deltaTime);
    }
    void RotateCharacter(float z, float yMouse)
    {
        transform.Rotate(0,yMouse * cam.GetSpeedRotation() * Time.deltaTime, 0);
    }
}
