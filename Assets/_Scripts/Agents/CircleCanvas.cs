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
        return circularSlider.DOValue(1f, duration, false).SetEase(Ease.Linear)
            .OnStart(() => circularSlider.gameObject.SetActive(true))
            .OnComplete(() =>
            {
                Debug.Log("Circle disappears");
                circularSlider.gameObject.SetActive(false);
                circularSlider.value = 0;
            });
    }
}
