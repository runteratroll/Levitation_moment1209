using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HpBar : MonoBehaviour
{
    public Image realHpBar;
    public Image twinHpBar;

    public float maxHp;
    public float hp;

    void Start()
    {
        hp = maxHp;
        
        
    }

    void Update()
    {
        realHpBar.DOFillAmount(hp / maxHp, 0.1f).SetEase(Ease.InOutBounce);
        twinHpBar.DOFillAmount(hp / maxHp, 0.2f).SetEase(Ease.InOutBounce);
    }
}
