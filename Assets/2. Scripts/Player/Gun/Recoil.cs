using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public PlayerRoot Player;

    public float reTime;
    public float re = 0;

    public float recoil = 1;

    int mp;
    private bool isRun = false;

    // Update is called once per frame
    void Update()
    {
        RunTime();
    }

    void RunTime()
    {
        if (isRun)
        {
            re += 1 * Time.deltaTime;

            if (re > reTime)
            {
                isRun = false;
                FinalRecoil();
            }
        }

    }

    public void Run()
    {
        re = 0;
        isRun = true;
        StartRecoil();
    }

    public void StartRecoil()
    {
        mp = Random.Range(0, 2);
        if (mp == 0)
        {
            Player.transform.DORotate(new Vector3(Player.xRotate -= Random.RandomRange(recoil * 1f, recoil * 1.5f),
            Player.yRotate += Random.RandomRange(recoil * 0.5f, recoil * 0.75f), 0), 0.025f);
        }
        if (mp == 1)
        {
            Player.transform.DORotate(new Vector3(Player.xRotate -= Random.RandomRange(recoil * 1f, recoil * 1.5f),
            Player.yRotate -= Random.RandomRange(recoil * 0.5f, recoil * 0.75f), 0), 0.025f);
        }
    }

    public void FinalRecoil()
    {
        mp = Random.Range(0, 2);
        if (mp == 0)
        {
            Player.transform.DORotate(new Vector3(Player.xRotate += Random.RandomRange(recoil * 0.5f, recoil * 0.75f),
            Player.yRotate -= Random.RandomRange(recoil * 0.25f, recoil * 0.375f), 0), 0.05f);
        }
        if (mp == 1)
        {
            Player.transform.DORotate(new Vector3(Player.xRotate += Random.RandomRange(recoil * 0.5f, recoil * 0.75f),
            Player.yRotate += Random.RandomRange(recoil * 0.25f, recoil * 0.375f), 0), 0.05f);
        }
    }
}
