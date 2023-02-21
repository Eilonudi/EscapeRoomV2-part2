using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameMenuManeger : MonoBehaviour
{

    public Transform head;
    public float spawnDistance = 2; 
    public GameObject menu;
    public InputActionProperty showButton;
    public GameObject suggestionsText;


    void Start()
    {
        // hide the menu when first initialized
        menu.SetActive(false);
        
    }

    
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);
            // Transforms the menu position according to the head position
            menu.transform.position =
                head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }
        
        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;
    }

    public void ExitGame()
    {
        GameManager.UpdateGameState(GameState.Exit);
    }
    
    public void StartGame()
    {
        GameManager.UpdateGameState(GameState.StartGame);
    }
    
    public void toggleSuggestions()
    {
        suggestionsText.SetActive(!suggestionsText.activeSelf);
    }
}
