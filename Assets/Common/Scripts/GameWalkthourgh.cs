using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWalkthourgh : MonoBehaviour
{
    public GameObject walkthroughCanvas;
    public GameObject xrRig;
    public GameObject trash;
    
    private int lastCompletedTaskNumber = 0;
    
    void Start()
    {
        if (Application.isEditor)
        {
            print("We are running this from inside of the editor!");
            walkthroughCanvas.SetActive(true);
        }
        else
        {
            walkthroughCanvas.SetActive(false);
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
    }
}
