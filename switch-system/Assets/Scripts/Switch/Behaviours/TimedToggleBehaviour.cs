using UnityEngine;

public class TimedToggleBehaviour : MonoBehaviour, IToggleBehaviour
{
    private float timeGone;
    private bool wasTriggered;
    private Switch s;
    private SimpleToggleBehaviour simpleToggleBehaviour;

    public float ToggleTime { get; private set; } = 2.0f;

    public static TimedToggleBehaviour Create(GameObject obj, float toggleTime)
    {
        TimedToggleBehaviour t = obj.AddComponent<TimedToggleBehaviour>();
        t.ToggleTime = toggleTime;
        return t;
    }

    #region Unity Cycle
    private void Awake()
    {
        this.simpleToggleBehaviour = new SimpleToggleBehaviour();
        this.ToggleTime = 2.0f;
        this.wasTriggered = false;
    }

    private void Start()
    {
        this.timeGone = this.ToggleTime;
    }

    private void Update()
    {
        if (this.timeGone <= 0.0f && this.wasTriggered)
        {
            this.simpleToggleBehaviour.Toggle(this.s);
            this.wasTriggered = false;
            this.timeGone = this.ToggleTime;
        }
        else if (this.wasTriggered)
        {
            this.timeGone -= Time.deltaTime;
        }
    }
    #endregion

    public void Toggle(Switch s)
    {
        if (!wasTriggered)
        {
            this.s = s;
            this.simpleToggleBehaviour.Toggle(this.s);
            this.wasTriggered = true;
        }
    }
}
