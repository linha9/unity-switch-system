using System.Collections.Generic;
using UnityEngine;

public interface IToggleBehaviour
{
    bool Toggle(bool isOn, List<GameObject> switchables);
}
