using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float _animationDuration;
    private void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), _animationDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
}
