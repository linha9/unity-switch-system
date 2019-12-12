using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> switchables;
    [SerializeField]
    private SwitchType type = SwitchType.TOGGLE;

    private IToggleBehaviour toggleBehaviour;

    public List<GameObject> Switchables { get => this.switchables; private set { this.switchables = value; } }
    public bool IsOn { get; set; }

    #region Unity Cycle
    private void Awake()
    {
        this.IsOn = false;

        // SEARCH FOR A WAY TO NOT USE THIS ENUM
        switch(this.type)
        {
            case SwitchType.SINGLE_USE:
                this.toggleBehaviour = new SingleToggleBehaviour(false);
                break;
            case SwitchType.TOGGLE:
                this.toggleBehaviour = new SimpleToggleBehaviour();
                break;
            case SwitchType.TIMED:
                // TIME SHOULD BE SELECTED THROUGH INSPECTOR
                this.toggleBehaviour = TimedToggleBehaviour.Create(this.gameObject, 2.0f);
                break;
            default:
                break;
        }
        
    }
    #endregion

    public void Toggle()
    {
        this.toggleBehaviour.Toggle(this);
    }
}