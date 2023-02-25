using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirstTaskTutorial : MonoBehaviour
{
    public GameObject ovenDoor;
    public GameObject xrRig;
    public UnityEvent onDoneAnimation;
    
    public void StartTaskAnimation()
    {
        xrRig.GetComponent<Animator>().Play("CamMoveOven");
        Invoke("StartAnimation", 1.0f);
    }

    private void StartAnimation()
    {
        GetComponent<Animator>().Play("PizzaMove");
    }
    

    public void OpenOven()
    {
        ovenDoor.GetComponent<Animator>().Play("OpenOven");
    }

    public void CloseOven()
    {
        ovenDoor.GetComponent<Animator>().Play("ClosingOven");
    }

    public void TurnOven()
    {
        onDoneAnimation.Invoke();
    }
}
