using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour, IObjectInteractable
{
    [SerializeField] private GameObject TextPanel;
    [SerializeField] private UnityEvent Interaction;
    public void Interact()
    {
        Interaction.Invoke();
    }
    public void ActiveTextInteraction(bool isActive)
    {
        TextPanel.transform.LookAt(Camera.main.transform.position);
        TextPanel.SetActive(isActive);
    }
}
