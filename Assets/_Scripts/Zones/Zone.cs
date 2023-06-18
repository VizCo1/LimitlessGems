using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class Zone : PersistentMonoBehaviour
{
    protected const int SLOTS_INDEX = 0;
    public int ActiveSpots;

    public int MaxActiveSpots { get; protected set; }

    public virtual void MoveAgentToSpot(AgentBase agent)
    {

    }
}
