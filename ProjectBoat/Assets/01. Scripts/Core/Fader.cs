using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Fader : MonoBehaviour
{
    public static Fader Instance { get; private set; }

    [SerializeField] private float fadeTime;
    [SerializeField] private Transform fadeImageTrm;

    private void Awake()
    {
        Instance = this;
    }

    public void FadeOut(Action onFadeOutAction)
    {
        fadeImageTrm.localPosition = new Vector3(2500, 0, 0);
        fadeImageTrm.DOLocalMove(new Vector3(0, 0, 0), fadeTime).OnComplete(() => onFadeOutAction?.Invoke());
    }

    public void FadeIn()
    {
        fadeImageTrm.localPosition = new Vector3(0, 0, 0);
        fadeImageTrm.DOLocalMove(new Vector3(-2500, 0, 0), fadeTime);
    }
}
