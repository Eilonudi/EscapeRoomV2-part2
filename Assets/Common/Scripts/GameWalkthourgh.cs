using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWalkthourgh : MonoBehaviour
{
    public GameObject walkthroughCanvas;
    public GameObject xrRig;
    public GameObject trash;
    public GameObject firstTask;
    public Button firstTaskBtn;
    public Button secondTaskBtn;
    public Button thridTaskBtn;
    public Button forthTaskBtn;
    void Start()
    {
        if (Application.isEditor)
        {
            Debug.Log("We are running this from inside of the editor!");
            walkthroughCanvas.SetActive(true);
            if (firstTaskBtn != null)
            {
                firstTaskBtn.interactable = true;
                secondTaskBtn.interactable = false;
                thridTaskBtn.interactable = false;
                forthTaskBtn.interactable = false;
                InitializeBtnListiners();
                xrRig.GetComponent<Animator>().enabled = true;
                firstTask.GetComponent<Animator>().enabled = true;
                trash.GetComponent<Animator>().enabled = true;
            }
        }
        else
        {
            walkthroughCanvas.SetActive(false);
            xrRig.GetComponent<Animator>().enabled = false;
            firstTask.GetComponent<Animator>().enabled = false;
            trash.GetComponent<Animator>().enabled = false;
        }
    }

    public void StartSecondTask()
    {
        xrRig.GetComponent<Animator>().Play("CamMoveTV");
    }
    
    public void StartThirdTask()
    {
        xrRig.GetComponent<Animator>().Play("CamMoveComputer");
    }
    
    public void StartForthTask()
    {
        xrRig.GetComponent<Animator>().Play("CamMoveDoorSign");
        Invoke("ThrowToTrash", 2.5f);
    }

    private void ThrowToTrash()
    {
        trash.GetComponent<Animator>().Play("TrashToGarbage");
        Invoke("GoOut", 3.0f);
    }

    private void GoOut()
    {
        xrRig.GetComponent<Animator>().Play("GoOut");
    }

    private void InitializeBtnListiners()
    {
        firstTaskBtn.onClick.AddListener(() =>
        {
            firstTaskBtn.interactable = false;
            secondTaskBtn.interactable = true;
        });
        
        secondTaskBtn.onClick.AddListener(() =>
        {
            secondTaskBtn.interactable = false;
            thridTaskBtn.interactable = true;
        });
        
        thridTaskBtn.onClick.AddListener(() =>
        {
            thridTaskBtn.interactable = false;
            forthTaskBtn.interactable = true;
        });
    }
}
