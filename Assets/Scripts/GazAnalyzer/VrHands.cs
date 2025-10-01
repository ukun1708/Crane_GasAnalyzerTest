using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class VrHands : MonoBehaviour
{
    [Inject] private GameManager gameManager;

    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;

    private void OnEnable()
    {
        gameManager.OnTakeObjectChanged += TakeObjectChanged;
    }

    private void OnDisable()
    {
        gameManager.OnTakeObjectChanged -= TakeObjectChanged;
    }

    private void TakeObjectChanged(Transform analyzer, Transform probe)
    {
        analyzer.SetParent(leftHand);
        probe.SetParent(rightHand);

        analyzer.DOLocalMove(Vector3.zero, .25f).SetEase(Ease.OutBack);
        analyzer.DOLocalRotate(Vector3.up * 140f, .5f).SetEase(Ease.OutBack);

        probe.DOLocalMove(Vector3.zero, .25f).SetEase(Ease.OutBack);
        probe.DOLocalRotate(Vector3.up * -140f, .5f).SetEase(Ease.OutBack);
    }
}
