using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CircleCanvas : MonoBehaviour
{

    [SerializeField] Slider circularSlider;

    public Tween AppearAndFill(float duration)
    {
        circularSlider.gameObject.SetActive(true);
        Tween t = circularSlider.DOValue(1f, duration, false).SetEase(Ease.Linear).OnComplete(() =>
        {
            Debug.Log("Tween finished");
            circularSlider.gameObject.SetActive(false);
        });

        return t;
    }
}
