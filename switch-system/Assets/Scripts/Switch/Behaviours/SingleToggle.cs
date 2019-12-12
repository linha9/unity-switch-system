using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleToggle : IToggleBehaviour
{
    public bool HasBeenUsed { get; private set; }

    public SingleToggle(bool hasBeenUsed)
    {
        this.HasBeenUsed = hasBeenUsed;
    }

    public bool Toggle(bool isOn, List<GameObject> switchables)
    {
        
        if (!isOn && !HasBeenUsed)
        {
            this.HasBeenUsed = true;
            switchables?.ForEach(s => s.GetComponent<ISwitchable>()?.TurnOn());
            return true;
        }
        else if (isOn && !HasBeenUsed)
        {
            this.HasBeenUsed = true;
            switchables?.ForEach(s => s.GetComponent<ISwitchable>()?.TurnOff());
            return false;
        }

        return isOn;
    }
}