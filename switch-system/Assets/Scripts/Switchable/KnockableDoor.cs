using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockableDoor : Door
{
    [SerializeField]
    [Range(1, 1000)]
    private int knockRequirement = 1;

    public int Knocks { get; private set; }


    public override void TurnOn()
    {
        this.Knocks += 1;

        if (this.Knocks >= this.knockRequirement)
        {
            base.TurnOn();
        }
        
    }

    public override void TurnOff()
    {
        this.Knocks -= 1;

        if (this.Knocks < this.knockRequirement)
        {
            base.TurnOff();
        }
    }
}
