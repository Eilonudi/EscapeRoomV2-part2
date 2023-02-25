using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashPuzzle : MonoBehaviour
{
    public int trashItems = 5;
    public GameObject door;
    public TextMeshProUGUI doorSignText;
    private Collider _trashcanCollider;
    private List <GameObject> _currentCollisions = new List <GameObject> ();
    private bool _solved = false;
    

    void Start()
    {
        _trashcanCollider = GetComponent<Collider>();
    }
    
    private void Awake()
    {
        GameManager.onFinishedTasks += OpenDoor;
    }

    private void OnDestroy()
    {
        GameManager.onFinishedTasks -= OpenDoor;
    }

    private void OnTriggerEnter(Collider col)
    {
        // Add the GameObject collided with to the list.
        _currentCollisions.Add(col.gameObject);
        if (!_solved && _currentCollisions.Count >= trashItems)
        { 
            ValidateSolved();   
        }
    }

    private void OnTriggerExit(Collider col)
    {
        // Remove the GameObject collided with from the list.
        _currentCollisions.Remove(col.gameObject);
    }

    private void ValidateSolved()
    {
        var trashCount = 0;
        foreach (GameObject gObject in _currentCollisions) {
            if (gObject.CompareTag("Trash"))
            {
                trashCount++;
            }
        }
        if (trashCount == trashItems)
        {
            _solved = true;
            GameManager.UpdateGameState(GameState.CompletedTask);
        }
    }

    private void OpenDoor()
    {
        door.GetComponent<Animator>().Play("Opening");
        doorSignText.text = "Bye Bye";
    }
}
