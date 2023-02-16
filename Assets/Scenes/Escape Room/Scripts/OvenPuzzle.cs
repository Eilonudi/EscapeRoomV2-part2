using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OvenPuzzle : MonoBehaviour
{
    public Transform pizzaTransform;
    private Collider _ovenCollider;

    private bool _isColliding = false;

    void Start()
    {
        _ovenCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        _isColliding = _ovenCollider.bounds.Contains(pizzaTransform.position);
    }

    void TurnOnOven()
    {
        if (_isColliding)
        {
            
        }
    }
}
