using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsManager : MonoBehaviour
{
    public bool armsEnabled = true;
    public GameObject player;
    void Awake()
    {
        player.GetComponent<GunCtrl>().isFind = armsEnabled;
        player.GetComponent<TorpedoCtrl>().isFind = !armsEnabled;
    }

    void Update()
    {
        ArmsChange();
    }

    void ArmsChange()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            armsEnabled = !armsEnabled;
            player.GetComponent<GunCtrl>().isFind = armsEnabled;
            player.GetComponent<TorpedoCtrl>().isFind = !armsEnabled;
        }
    }
}
