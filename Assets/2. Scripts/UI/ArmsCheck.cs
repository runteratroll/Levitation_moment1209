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
            // mainArms.rectTransform.position = mainRect;
            // secondArms.rectTransform.position = secondRect;
            mainArms.rectTransform.DOAnchorPos(mainRect, 0.1f).SetEase(Ease.OutSine);
            secondArms.rectTransform.DOAnchorPos(secondRect, 0.1f).SetEase(Ease.OutSine);
            //mainArms.rectTransform.sizeDelta = new Vector2(150,150);
            mainArms.rectTransform.DOSizeDelta(new Vector2(150, 150), 0.1f).SetEase(Ease.OutSine);
            //secondArms.rectTransform.sizeDelta = new Vector2(100,100);
            secondArms.rectTransform.DOSizeDelta(new Vector2(100, 100), 0.1f).SetEase(Ease.OutSine);
        }
        else
        {
            secondArms.gameObject.SetActive(true);
            if (armsManager.armsEnabled)
            {
                // mainArms.rectTransform.position = mainRect;
                // secondArms.rectTransform.position = secondRect;
                mainArms.rectTransform.DOAnchorPos(mainRect, 0.1f).SetEase(Ease.OutSine);
                secondArms.rectTransform.DOAnchorPos(secondRect, 0.1f).SetEase(Ease.OutSine);
                //mainArms.rectTransform.sizeDelta = new Vector2(150,150);
                mainArms.rectTransform.DOSizeDelta(new Vector2(150, 150), 0.1f).SetEase(Ease.OutSine);
                //secondArms.rectTransform.sizeDelta = new Vector2(100,100);
                secondArms.rectTransform.DOSizeDelta(new Vector2(100, 100), 0.1f).SetEase(Ease.OutSine);
            }
            else
            {
                // mainArms.rectTransform.position = secondRect;
                // secondArms.rectTransform.position = mainRect;
                mainArms.rectTransform.DOAnchorPos(secondRect, 0.1f).SetEase(Ease.OutSine);
                secondArms.rectTransform.DOAnchorPos(mainRect, 0.1f).SetEase(Ease.OutSine);
                // mainArms.rectTransform.sizeDelta = new Vector2(100,100);
                mainArms.rectTransform.DOSizeDelta(new Vector2(100, 100), 0.1f).SetEase(Ease.OutSine);
                // secondArms.rectTransform.sizeDelta = new Vector2(150,150);
                secondArms.rectTransform.DOSizeDelta(new Vector2(150, 150), 0.1f).SetEase(Ease.OutSine);
            }
        }
    }
}
