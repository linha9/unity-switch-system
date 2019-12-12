using System.Collections.Generic;
using UnityEngine;

public class SimpleToggleBehaviour : IToggleBehaviour
{
    public SimpleToggleBehaviour()
    {

    }

    public void Toggle(Switch s)
    {
        if (!s.IsOn)
        {
            s.Switchables?.ForEach(switchable => switchable.GetComponent<ISwitchable>()?.TurnOn());
            s.IsOn = true;
        }
        else
        {
            s.Switchables?.ForEach(switchable => switchable.GetComponent<ISwitchable>()?.TurnOff());
            s.IsOn = false;
        }
    }
}
