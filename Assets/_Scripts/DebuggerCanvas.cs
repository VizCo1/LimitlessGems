using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebuggerCanvas : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    private void Update()
    {
        text.text = (1.0f / Time.deltaTime).ToString();
    }
}
