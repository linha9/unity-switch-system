using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleToggleBehaviour : IToggleBehaviour
{
    public bool HasBeenUsed { get; private set; }

    public SingleToggleBehaviour(bool hasBeenUsed)
    {
        this.HasBeenUsed = hasBeenUsed;
    }

    public void Toggle(Switch s)
    {
        if (!s.IsOn && !HasBeenUsed)
        {
            this.HasBeenUsed = true;
            s.Switchables?.ForEach(switchable => switchable.GetComponent<ISwitchable>()?.TurnOn());
            s.IsOn = true;
        }
        else if (s.IsOn && !HasBeenUsed)
        {
            this.HasBeenUsed = true;
            s.Switchables?.ForEach(switchable => switchable.GetComponent<ISwitchable>()?.TurnOff());
            s.IsOn = false;
        }
    }
}