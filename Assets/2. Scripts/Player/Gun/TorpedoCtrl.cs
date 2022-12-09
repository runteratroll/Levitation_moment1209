using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoCtrl : MonoBehaviour
{
    [Header("장전")]
    public float reloadTime;
    public float randomReloadTime;
    public float reload = 0;
    public bool isFind = true;

    [Header("집탄")]
    [Range(50, 300)] public float dispersion = 1; // 최대로 분산될수 있는 거리( 10km당 nM)
    [Range(1f, 3f)] public float sigma = 1; // 시그마가 1일때 보다 3일때 3배 중앙으로 모일확률이 높음
    private float realdispersion; // 최대분산을 수치화
    public float rng; // 실제 분산

    int i = 0;
    private bool isTorpedo = false;
    

    [Header("프리팹")]
    public GameObject torpedo;
    public TorpedoData[] torpedoDatas;
    public AudioSource audioSource;
    

    void Awake()
    {
        randomReloadTime = reloadTime + Random.RandomRange(-(reload * 0.1f), (reload * 0.1f));
        reload = randomReloadTime;
        dispersion = dispersion * 0.02f;
    }

    void Update()
    {
        TorpedoFire();
        TorpedoTime();
    }

    void TorpedoFire()
    {
        if (Input.GetMouseButton(0) && isTorpedo == false && isFind)
        {
            randomReloadTime = reloadTime + Random.RandomRange(-(reload * 0.1f), (reload * 0.1f));
            isTorpedo = true;
            audioSource.Play();

            if (i == torpedoDatas.Length) i = 0;

            float rol = 1;
            for (int bar = 0; bar < torpedoDatas[i].barrel; bar++)
            {
                rng = Random.RandomRange(1, sigma);
                float realRng = Random.RandomRange(dispersion / (rng / 2), dispersion / (rng));
                Quaternion pos = torpedoDatas[i].pos.transform.rotation;
                pos.x = 0;
                Instantiate(torpedo, torpedoDatas[i].pos.transform.position, pos
                    * Quaternion.Euler(0, bar * realRng, realRng * 0.5f));

                rol *= -1;
            }
            //torpedoDatas[i].particleSystem.Play();


            i++;

            reload = 0;
        }
    }

    void TorpedoTime()
    {
        if (isTorpedo)
        {
            reload += 1 * Time.deltaTime;

            if (reload >= randomReloadTime)
            {
                reload = randomReloadTime;
                isTorpedo = false;
            }
        }
    }

    
[System.Serializable]
public class TorpedoData
{
    public int barrel;
    public GameObject pos;
}
}
