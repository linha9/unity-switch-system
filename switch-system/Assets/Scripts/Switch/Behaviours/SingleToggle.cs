public class SingleToggleBehaviour : IToggleBehaviour
{
    private bool hasBeenUsed;

    public SingleToggleBehaviour(bool hasBeenUsed)
    {
        this.hasBeenUsed = hasBeenUsed;
    }

    public void Toggle(Switch s)
    {
        if (!s.IsOn && !hasBeenUsed)
        {
            this.hasBeenUsed = true;
            s.Switchables?.ForEach(switchable => switchable.GetComponent<ISwitchable>()?.TurnOn());
            s.IsOn = true;
        }
        else if (s.IsOn && !hasBeenUsed)
        {
            this.hasBeenUsed = true;
            s.Switchables?.ForEach(switchable => switchable.GetComponent<ISwitchable>()?.TurnOff());
            s.IsOn = false;
        }
    }
}