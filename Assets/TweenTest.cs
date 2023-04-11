using DG.Tweening;
using EasyButtons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTest : MonoBehaviour
{
    public Ease ease;
    public LoopType loopType;

    public Vector3 endValue;
    public float duration;

    [Button]
    void Test(Vector3 endValue, float duration) 
    {
        transform.DOMove(endValue, duration)
            .SetEase(ease)
            .SetLoops(-1, loopType);
    }
}
