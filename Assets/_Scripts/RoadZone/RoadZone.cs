using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadZone : Zone
{
    public override void MoveAgentToSpot(AgentBase agent)
    {
        agent.GoToNextPosition();
    }
}
