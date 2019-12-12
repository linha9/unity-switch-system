using System.Collections.Generic;
using UnityEngine;

public class SimpleToggle : IToggleBehaviour
{
    public SimpleToggle()
    {

    }

    public bool Toggle(bool isOn, List<GameObject> switchables)
    {
        if (!isOn)
        {
            switchables?.ForEach(s => s.GetComponent<ISwitchable>()?.TurnOn());
            return true;
        }
        else
        {
            switchables?.ForEach(s => s.GetComponent<ISwitchable>()?.TurnOff());
            return false;
        }
    }
}
