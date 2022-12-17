using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WarningSignDotween : MonoBehaviour
{


    private Image sign;

    private void Awake()
    {
        sign = GetComponent<Image>();
    }
    private void Start()
    {
        //투명해지다가 원래로돌아오고 이걸 3번반복하면 됨

        //sign.rectTransform.transform.DOLocalMoveX(0, 2f).SetEase(Ease.OutSine).OnComplete(() =>
        //    sign.rectTransform.transform.DOLocalMoveX(2000f, 2f).SetEase(Ease.InSine)
        //) ;
        sign.DOFade(0.3f, 0.5f).SetLoops(4, LoopType.Yoyo).OnComplete(() =>
        Destroy(transform.parent.gameObject)
        );



    }
}
