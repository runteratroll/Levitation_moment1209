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
        //���������ٰ� �����ε��ƿ��� �̰� 3���ݺ��ϸ� ��

        //sign.rectTransform.transform.DOLocalMoveX(0, 2f).SetEase(Ease.OutSine).OnComplete(() =>
        //    sign.rectTransform.transform.DOLocalMoveX(2000f, 2f).SetEase(Ease.InSine)
        //) ;
        sign.DOFade(0.3f, 0.5f).SetLoops(4, LoopType.Yoyo).OnComplete(() =>
        Destroy(transform.parent.gameObject)
        );



    }
}
