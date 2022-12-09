using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullBurst : MonoBehaviour
{
    public Recoil Recoil;
    public GunCtrl GunCtrl;

    public float randomReloadTime;
    public float reloadTime;
    public float reload = 0;

    private bool isGun = false;

    public int burstint = 0;

    public GameObject Bullet;
    int i = 0;

    void Start()
    {
        randomReloadTime = reloadTime + Random.RandomRange(-(reload * 0.1f), (reload * 0.1f));
        reload = randomReloadTime;
    }

    void Update()
    {
        GunTime();
        BurstInput();
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

    void BurstInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && isGun == false)
        {
            StartCoroutine(Burst());
        }
    }

    IEnumerator Burst()
    {
        for (int i = 0; i < burstint; i++)
        {
            Fire();
            yield return new WaitForSeconds(GunCtrl.randomReloadTime / 5);
        }

    }

    void Fire()
    {
        randomReloadTime = reloadTime + Random.RandomRange(-(reload * 0.1f), (reload * 0.1f));
        isGun = true;
        Recoil.Run();

        if (i == GunCtrl.gunDatas.Length) i = 0;

        float rol = 1;
        for (int bar = 0; bar < GunCtrl.gunDatas[i].barrel; bar++)
        {
            GunCtrl.rng = Random.RandomRange(1, GunCtrl.sigma);
            float realRng = Random.RandomRange(GunCtrl.dispersion * 0.1f, GunCtrl.dispersion / GunCtrl.rng);
            Instantiate(Bullet, GunCtrl.gunDatas[i].pos.transform.position, GunCtrl.gunDatas[i].pos.transform.rotation
                * Quaternion.Euler(realRng * 0.5f, bar * realRng, realRng * 0.5f));

            rol *= -1;
        }
        GunCtrl.gunDatas[i].particleSystem.Play();

        GunCtrl.gunSoundManager.SoundPlay();
        i++;

        reload = 0;
    }
}
