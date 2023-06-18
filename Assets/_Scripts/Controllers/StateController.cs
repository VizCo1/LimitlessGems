using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ZSerializer;
using ZSerializer.Internal;

public class StateController : MonoBehaviour
{
    private void Awake()
    {
        Application.quitting += () => ZSerialize.SaveScene();
        //[RuntimeInitializeOnLoadMethod]
        // https://docs.unity3d.com/ScriptReference/RuntimeInitializeOnLoadMethodAttribute.html
    }

    private void OnApplicationPause(bool pause)
    {
        ZSerialize.SaveScene();
    }

    private void Start()
    {
        ZSerialize.LoadScene();
    }
}
