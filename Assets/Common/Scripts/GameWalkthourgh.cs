using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWalkthourgh : MonoBehaviour
{
    public GameObject walkthroughCanvas;
    public GameObject xrRig;
    
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
}
