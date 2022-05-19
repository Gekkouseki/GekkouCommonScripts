using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LittleMove : MonoBehaviour
{
    private enum MoveType
    { 
        OffsetIsTargetPoint,
        OffsetIsStartPoint,
    }

    [SerializeField]
    private MoveType moveType;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float moveTime = 2.0f;

    [SerializeField]
    private Ease ease;

    [SerializeField]
    private RectTransform rectTrans;

    private void Start()
    {
        if (moveType == MoveType.OffsetIsTargetPoint)
            TargetPointMove();
        else
            StartPointMove();
    }

    private void TargetPointMove()
    {
        rectTrans.DOMove(rectTrans.position + offset, moveTime).SetEase(ease);
    }

    private void StartPointMove()
    {
        var start = rectTrans.position;
        rectTrans.position += offset;
        rectTrans.DOMove(start, moveTime).SetEase(ease);
    }
}
