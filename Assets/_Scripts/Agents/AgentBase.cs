using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBase : MonoBehaviour
{
    [SerializeField] protected Transform[] positions;
    protected int index = 0;

    protected NavMeshAgent agent;

    [SerializeField] protected bool b;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

   public void SetDestination(Vector3 pos)
    {
        agent.destination = new Vector3(pos.x, transform.localPosition.y, pos.z);
    }

    public virtual void GoToNextPosition()
    {
        /*if (!canGoToNextPosition)
            return;
        else
            canGoToNextPosition = false;*/

        if (b)
            Debug.Log("GO TO NEXT POSITION");

        //DOVirtual.DelayedCall(0.5f, () => canGoToNextPosition = true);
        
        if (index < positions.Length - 1)
            agent.destination = positions[index++].position;
        else
        {
            agent.destination = positions[index].position;
            index = 0;
        }
    }

    public void ChangeTag(string t)
    {
        tag = t;
    }
}
