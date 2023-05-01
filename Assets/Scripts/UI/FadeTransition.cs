using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    [SerializeField] float timeToFade;
    Image image;

    private void OnEnable()
    {
        image = GetComponent<Image>();
        image.DOColor(new Color(image.color.r, image.color.g, image.color.b, 0), timeToFade);
    }

    private void OnDisable()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 255);
    }

    private void Awake()
    {
        Time.timeScale = 1f;
    }
}
