using UnityEngine;

public class Door : MonoBehaviour, ISwitchable
{
    [SerializeField]
    private bool isOpen = false;

    public bool IsOpen { get => this.isOpen; private set => this.isOpen = value; }

    public virtual void TurnOn()
    {
        if (!this.IsOpen) {
            this.IsOpen = true;
            Debug.Log("Door is now open");
        }
    }

    public virtual void TurnOff()
    {
        if (this.IsOpen)
        {
            this.IsOpen = false;
            Debug.Log("Door is now closed");
        }
    }
}
