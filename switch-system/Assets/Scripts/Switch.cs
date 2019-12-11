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

    #region Public Interface
    [SerializeField]
    private bool iniIsOn;
    [SerializeField]
    private List<ISwitchable> switchables;
    #endregion

    private bool isOn;

    #region Unity Cycle
    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #endregion
}
