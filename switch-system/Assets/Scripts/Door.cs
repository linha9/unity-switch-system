using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// CREATE A KNOCKABLE DOOR
public class Door : MonoBehaviour, ISwitchable
{
    private bool isOpen;

    public void TurnOn()
    {
        if (!isOpen) {
            this.isOpen = true;
            Debug.Log("Door is now open");
        }
    }

    public void TurnOff()
    {
        Debug.Log("run");
        if (isOpen)
        {
            this.isOpen = false;
            Debug.Log("Door is now closed");
        }
    }
}
