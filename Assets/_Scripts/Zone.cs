using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    protected const int SLOTS_INDEX = 0;
    [SerializeField] protected int activeSpots;

    public virtual void MoveAgentToSpot(AgentBase agent)
    {

    }
}
