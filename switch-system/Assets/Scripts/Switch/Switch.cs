using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Switch : MonoBehaviour
{
    [SerializeField]
    private bool isActive = true;
    [SerializeField]
    private List<GameObject> switchables;
    [SerializeField]
    private SwitchType type = SwitchType.TOGGLE;
    [SerializeField]
    private float time = 2.0f;

    private IToggleBehaviour toggleBehaviour;

    public List<GameObject> Switchables { get => this.switchables; private set => this.switchables = value; }
    public bool IsOn { get; set; }
    public bool IsActive { get => this.isActive; private set => this.isActive = value; }

    #region Unity Cycle
    private void Awake()
    {
        this.IsOn = false;

        switch(this.type)
        {
            case SwitchType.SINGLE_USE:
                this.toggleBehaviour = new SingleToggleBehaviour(false);
                break;
            case SwitchType.TOGGLE:
                this.toggleBehaviour = new SimpleToggleBehaviour();
                break;
            case SwitchType.TIMED:
                this.toggleBehaviour = TimedToggleBehaviour.Create(this.gameObject, this.time);
                break;
            default:
                break;
        }
    }
    #endregion

    public virtual void Toggle()
    {
        if (this.IsActive)
        {
            this.toggleBehaviour.Toggle(this);
        }
    }
}