﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiProjectilAtkBehaviour : AtkBehaviour
{
    public AudioSource audioSource;
    public ParticleSystem particle;
    public float pitch;


    [Header("집탄")]
    [Range(1f, 30f)] public float dispersion = 1; // 최대로 분산될수 있는 거리( 10km당 nM)
    [Range(1f, 3f)] public float sigma = 1; // 시그마가 1일때 보다 3일때 3배 중앙으로 모일확률이 높음
    private float realdispersion; // 최대분산을 수치화
    public float rng; // 실제 분산

    

    public override void callAtkMotion(GameObject target = null, Transform posAtkStart = null)
    {
        if (target == null && posAtkStart != null) //Ÿ���� ����, �߻���ġ����
        {
            return;
        }
        //Ÿ���� �����ִ� �Ű��� 
        Debug.Log("멀티슛 되니?");

        if (audioSource != null)
        {


            pitch = Random.RandomRange(0.8f, 1.2f);
            audioSource.pitch = pitch;

            audioSource.Play();
        }

        if (particle != null)
        {
            particle.Play();
        }


        Vector3 vecProjectile = posAtkStart?.position ?? transform.position; //�߻���ġ�� ���̶�� �ڱ���ġ����

        if (atkEffectPrefab != null)
        {



            //�������� ������� 
            GameObject objProjectile = GameObject.Instantiate<GameObject>(atkEffectPrefab, vecProjectile, Quaternion.identity);
            //�ٵ� �� �̰� �� rprojedtil�� �����ϱ� Ÿ�ٵ� ������

            Vector3 l_vector = target.transform.position - transform.position;
            Quaternion ro = Quaternion.LookRotation(l_vector).normalized; //position���� ����
            objProjectile.transform.forward = transform.forward; //������ �θ��� forward�� ����. �� �����ΰ�
            objProjectile.transform.rotation = ro;

            

         

            Main410mmProejctilAtk[] projectile = objProjectile.GetComponentsInChildren<Main410mmProejctilAtk>(); //�������� �̰� ������ �̝��� �ϰ�
            Transform[] childs = objProjectile.GetComponentsInChildren<Transform>();
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i].parent = null;
            }                                                                                       //bulletMove���� CollisionprojectilAtk�� ��Ӿȹ����ϱ� �ù�
                                                                                                    //projectile.gameObject.AddComponent<peripheralRange>();

            for (int i = 0; i < projectile.Length; i++)
            {
                if (projectile[i] != null)
                {
                    projectile[i].projectileParents = this.gameObject;  //�θ� ����� 
                    projectile[i].target = target;
                    projectile[i].attackBehaviour = this;



           
                   
                    rng = Random.Range(1f, sigma);
                    float realRng = Random.Range(dispersion * 0.1f, dispersion / rng);

                    //Quaternion.Euler(realRng * 0.5f, bar * realRng, realRng * 0.5f));

                    float x = Random.Range(target.transform.position.x - 1f * realRng * 0.5f, target.transform.position.x + 1f * realRng * 0.5f);
                    float z = Random.Range(target.transform.position.z - 1f * realRng * 0.5f, target.transform.position.z + 1f * realRng * 0.5f);



                    Vector3 vec = new Vector3(x, target.transform.position.y, z);
                    projectile[i].transform.LookAt(vec);

                    projectile[i].InstanceDamageAround(vec);
                    //add 해줘야 겠다.
                    //peripheralRange peripheral = new peripheralRange(target, projectile.gameObject);

                }
            }

       

            Destroy(objProjectile);
            //타겟위치 넘겨주고 adad( target,projecitle,
            //그곳에 빨간 표시 해주고, 그부분에 자기가 쏜 불렛이 들어가면 physics콜라이더
            //bullet에 그걸 넣고
        }


        //타겟의 위치에 범위 그리기

        nowAtkCoolTime = 0.0f;
    }

}
