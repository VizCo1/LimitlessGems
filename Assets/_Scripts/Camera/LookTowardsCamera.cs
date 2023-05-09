using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardsCamera : MonoBehaviour
{
    private void Awake()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
