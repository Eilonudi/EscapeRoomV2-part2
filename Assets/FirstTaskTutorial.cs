using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTaskTutorial : MonoBehaviour
{
    public GameObject ovenDoor;
    public GameObject pizza;
    void Start()
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
}
