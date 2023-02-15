using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportRay : MonoBehaviour
{
    [SerializeField] private float sensitivity = 0.05f;
    
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;
        
    
    void Update()
    {
        leftTeleportation.SetActive(leftActivate.action.ReadValue<float>() > sensitivity);
        rightTeleportation.SetActive(rightActivate.action.ReadValue<float>() > sensitivity);
    }
}
