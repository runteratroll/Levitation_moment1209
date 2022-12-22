using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public Image fire;
    public Image torpedo;
    public Image burst;

    [SerializeField] private GunCtrl gunCtrl;
    [SerializeField] private FullBurst fullBurst;
    [SerializeField] private TorpedoCtrl torpedoCtrl;

    void Update()
    {
        gunCtrl = FindObjectOfType<GunCtrl>();
        fullBurst = FindObjectOfType<FullBurst>();
        torpedoCtrl = FindObjectOfType<TorpedoCtrl>();
        UIUpdate();
    }

    void UIUpdate()
    {
        fire.fillAmount = gunCtrl.reload / gunCtrl.randomReloadTime;
        burst.fillAmount = fullBurst.reload / fullBurst.randomReloadTime;

        if(torpedoCtrl != null)
        {
            torpedo.fillAmount = torpedoCtrl.reload / torpedoCtrl.randomReloadTime;
        }
    }
}
