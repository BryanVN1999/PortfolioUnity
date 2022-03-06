using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    [SerializeField][Range(0,90)] private int maxAngle;
    [SerializeField] private float speedRotation;
    [SerializeField] private float distanceRay;
    float degreeX;
    bool buttonPressed;
    IObjectInteractable preObject;
    public float GetSpeedRotation()
    {
        return speedRotation;
    }
    private void Awake() 
    {
        degreeX = 0;
        buttonPressed = false;
        preObject = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E) && preObject != null)
            buttonPressed = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RotateCamera(Input.GetAxis("Mouse Y"));
        RayToInteract(distanceRay);
    }
    private void RayToInteract(float maxDistance)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, Physics.AllLayers, QueryTriggerInteraction.Collide))
        {
            IObjectInteractable interactable = hit.collider.GetComponent<IObjectInteractable>();
            if(interactable != null)
            {
                preObject = interactable;
                interactable.ActiveTextInteraction(true);
                if(buttonPressed)
                {
                    interactable.ActiveTextInteraction(false);
                    interactable.Interact();
                    buttonPressed = false;
                }
            } else {
                if(preObject != null)
                {
                    preObject.ActiveTextInteraction(false);
                    preObject = null;
                }
                buttonPressed = false;
            }
        } else 
        {
            if(preObject != null)
            {
                preObject.ActiveTextInteraction(false);
                preObject = null;
            }
        }
    }
    private void RotateCamera(float x)
    {
        Vector3 eulerRot;
        degreeX += x * speedRotation * Time.deltaTime * -1f;
        degreeX = Mathf.Clamp(degreeX, maxAngle * -1f, maxAngle);
        eulerRot = new Vector3(degreeX, transform.rotation.eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(eulerRot);
    }
}
