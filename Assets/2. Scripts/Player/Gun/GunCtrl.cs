using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCtrl : MonoBehaviour
{
    [Header("스크립트")]
    public Recoil Recoil;
    public GunSoundManager gunSoundManager;
    
    [Header("장전")] 
    public float reloadTime;
    public float randomReloadTime;
    public float reload = 0;
    public bool isFind = true;
    
    [Header("집탄")] 
    [Range(50,300)] public float dispersion = 1; // 최대로 분산될수 있는 거리( 10km당 nM)
    [Range(1f,3f)] public float sigma = 1; // 시그마가 1일때 보다 3일때 3배 중앙으로 모일확률이 높음
    private float realdispersion; // 최대분산을 수치화
    public float rng; // 실제 분산

    int i = 0;
    private bool isGun = false;
    

    [Header("프리팹")] 
    public GameObject Bullet;
    public GunData[] gunDatas;

    void Awake()
    {
        randomReloadTime = reloadTime + Random.RandomRange(-(reload * 0.1f), (reload * 0.1f));
        reload = randomReloadTime;
        dispersion = dispersion * 0.02f;
    }
    void Update()
    {
        GunTime();
        GunFire();
    }

    void GunFire()
    {
        if (Input.GetMouseButton(0) && isGun == false && isFind)
        {
            randomReloadTime = reloadTime + Random.RandomRange(-(reload * 0.1f), (reload * 0.1f));
            isGun = true;
            Recoil.Run();

            if (i == gunDatas.Length) i = 0;

            float rol = 1;
            for (int bar = 0; bar < gunDatas[i].barrel; bar++)
            {
                rng = Random.RandomRange(1, sigma);
                float realRng = Random.RandomRange(dispersion * 0.1f, dispersion / rng);
                Instantiate(Bullet, gunDatas[i].pos.transform.position, gunDatas[i].pos.transform.rotation
                    * Quaternion.Euler(realRng * 0.5f, bar * realRng, realRng * 0.5f));

                rol *= -1;
            }
            gunDatas[i].particleSystem.Play();

            gunSoundManager.SoundPlay();

            i++;

            reload = 0;
        }
    }

    void GunTime()
    {
        if (isGun)
        {
            reload += 1 * Time.deltaTime;

            if (reload >= randomReloadTime)
            {
                reload = randomReloadTime;
                isGun = false;
            }
        }
    }

}

[System.Serializable]
public class GunData
{
    public int barrel;
    public GameObject pos;
    public ParticleSystem particleSystem;
}