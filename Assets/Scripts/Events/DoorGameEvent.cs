using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGameEvent : GameEvent
{
    public string Doornum;

    public DoorGameEvent(string Doornum)
    {
       this.Doornum = Doornum;
    }
}
