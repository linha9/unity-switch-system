using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public enum SwitchType
    {
        SINGLE_USE,
        TOGGLE,
        TIMED
    }

    #region Inspector Variables
    [SerializeField]
    private List<GameObject> switchables;
    [SerializeField]
    private SwitchType type;
    #endregion

    private IToggleBehaviour toggleBehaviour;
    public bool IsOn { get; private set; }


    #region Unity Cycle
    private void Awake()
    {
        this.IsOn = false;

        // SEARCH FOR A WAY TO NOT USE THIS ENUM
        switch(this.type)
        {
            case SwitchType.SINGLE_USE:
                this.toggleBehaviour = new SingleToggle(false);
                break;
            case SwitchType.TOGGLE:
                this.toggleBehaviour = new SimpleToggle();
                break;
            case SwitchType.TIMED:
                //TO BE IMPLEMENTED
                break;
            default:
                break;
        }
        
    }
    #endregion

    public void Toggle()
    {
        IsOn = this.toggleBehaviour.Toggle(IsOn, switchables);
    }
}

// TO IMPLEMENT TIMED TOGGLE WE NEED EVENTS AND CALLBACKS
public class TimedToggle : MonoBehaviour, IToggleBehaviour
{
    public float ToggleTime { get; set; } = 2.0f;

    private float timeGone;
    private bool wasTriggered;

    private void Awake()
    {
        this.ToggleTime = 2.0f;
        this.wasTriggered = false;
    }
    private void Start()
    {
        //this.timeGone = this.time;
    }

    private void Update()
    {

    }

    public bool Toggle(bool isOn, List<GameObject> switchables)
    {
        if (!isOn && !wasTriggered)
        {
            switchables?.ForEach(s => s.GetComponent<ISwitchable>()?.TurnOn());
            return true;
        }
        else if (isOn && !wasTriggered)
        {
            switchables?.ForEach(s => s.GetComponent<ISwitchable>()?.TurnOff());
            return false;
        }

        return isOn;
    }
}