using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBase : MonoBehaviour
{
    [SerializeField] protected Transform[] positions;
    //[SerializeField] protected Animator animator;
    protected int index = 0;

    public NavMeshAgent agent { get; protected set; }

    protected Sequence animationSeq;

    protected Transform model;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        model = transform.GetChild(0);

        Quaternion modelInitialRotation = model.rotation;
        Quaternion initialRotation = transform.rotation;

        animationSeq = DOTween.Sequence()
            .Append(model.DORotate(new Vector3(-10, 0, 0), 0.5f, RotateMode.LocalAxisAdd))
            .Append(model.DORotate(new Vector3(10, 0, 0), 0.5f, RotateMode.LocalAxisAdd))
            .Append(model.DORotate(new Vector3(10, 0, 0), 0.5f, RotateMode.LocalAxisAdd))
            .Append(model.DORotate(new Vector3(-10, 0, 0), 0.5f, RotateMode.LocalAxisAdd))
            .OnPause(() => { transform.rotation = initialRotation; model.rotation = modelInitialRotation; })
            .SetLoops(-1);
    }

   public void SetDestination(Vector3 pos)
    {
        agent.destination = new Vector3(pos.x, transform.localPosition.y, pos.z);
    }

    public virtual void GoToNextPosition()
    {     
        if (index < positions.Length - 1)
            SetDestination(positions[index++].position);
        else
        {
            SetDestination(positions[index].position);
            index = 0;
        }
    }

    public void ChangeTag(string t)
    {
        tag = t;
    }
}
