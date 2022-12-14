using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextDotween : MonoBehaviour
{

    
    private void Start()
    {
        RectTransform rect = transform.GetComponent<RectTransform>();


        rect.DOAnchorPosY(145f, 0.6f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.OutCubic);
    }
}
