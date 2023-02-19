using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class OvenPuzzle : MonoBehaviour
{
    public Transform pizzaTransform;
    public GameObject startButton;
    public TextMeshProUGUI ovenTimer;
    private Collider _ovenCollider;

    private bool _isColliding = false;

    void Start()
    {
        _ovenCollider = GetComponent<Collider>();
        startButton.GetComponentInChildren<ButtonVR>().onRelease.AddListener(TurnOnOven);
    }

    // Update is called once per frame
    void Update()
    {
        _isColliding = _ovenCollider.bounds.Contains(pizzaTransform.position);
    }

    void TurnOnOven()
    {
        Debug.Log("pressed");
        if (_isColliding)
        {
            startButton.GetComponentInChildren<TextMeshProUGUI>().text = "Stop";
            ovenTimer.text = "C56:78";
        }
    }
}
