using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CircleCanvas : MonoBehaviour
{

    [SerializeField] Slider circularSlider;

    public Tween AppearAndFill()
    {
        circularSlider.gameObject.SetActive(true);
        return circularSlider.DOValue(1f, 5f, false).SetEase(Ease.Linear).OnComplete(() =>
        {

            Debug.Log("Tween finished");
            circularSlider.gameObject.SetActive(false);
        }).Pause();
    }
}
