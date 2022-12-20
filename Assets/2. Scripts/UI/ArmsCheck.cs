using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ArmsCheck : MonoBehaviour
{
    public ArmsManager armsManager;
    public Vector3 mainRect;
    public Vector3 secondRect;

    public Image mainArms;
    public Image secondArms;
    public Image zHotKey;
    void Awake()
    {
        //mainRect = mainArms.rectTransform.position;
        //secondRect = secondArms.rectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        armsManager = FindObjectOfType<ArmsManager>();
        Check();

    }

    void Check()
    {
        if (armsManager == null)
        {
            secondArms.gameObject.SetActive(false);
            zHotKey.gameObject.SetActive(false);
            mainArms.rectTransform.DOAnchorPos(mainRect, 0.1f).SetEase(Ease.OutSine);
            secondArms.rectTransform.DOAnchorPos(secondRect, 0.1f).SetEase(Ease.OutSine);
            mainArms.rectTransform.DOSizeDelta(new Vector2(125, 125), 0.1f).SetEase(Ease.OutSine);
            secondArms.rectTransform.DOSizeDelta(new Vector2(100, 100), 0.1f).SetEase(Ease.OutSine);
        }
        else
        {
            secondArms.gameObject.SetActive(true);
            zHotKey.gameObject.SetActive(true);
            if (armsManager.armsEnabled)
            {
                mainArms.rectTransform.DOAnchorPos(mainRect, 0.1f).SetEase(Ease.OutSine);
                secondArms.rectTransform.DOAnchorPos(secondRect, 0.1f).SetEase(Ease.OutSine);
                mainArms.rectTransform.DOSizeDelta(new Vector2(125, 125), 0.1f).SetEase(Ease.OutSine);
                secondArms.rectTransform.DOSizeDelta(new Vector2(100, 100), 0.1f).SetEase(Ease.OutSine);
            }
            else
            {
                mainArms.rectTransform.DOAnchorPos(secondRect, 0.1f).SetEase(Ease.OutSine);
                secondArms.rectTransform.DOAnchorPos(mainRect, 0.1f).SetEase(Ease.OutSine);
                mainArms.rectTransform.DOSizeDelta(new Vector2(100, 100), 0.1f).SetEase(Ease.OutSine);
                secondArms.rectTransform.DOSizeDelta(new Vector2(125, 125), 0.1f).SetEase(Ease.OutSine);
            }
        }
    }
}
