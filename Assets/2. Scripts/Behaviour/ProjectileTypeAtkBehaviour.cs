using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTypeAtkBehaviour : AtkBehaviour 
{

    public AudioSource audioSource;
    public ParticleSystem particle;
    public float pitch;


    public bool isDamageAround;
    public Transform[] pos;
    public int barrel;
    int bar = 0;

    [Header("집탄")]
    [Range(1, 30)] public float dispersion = 1; // 최대로 분산될수 있는 거리( 10km당 nM)
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
        Debug.Log("aa");

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
          

            for (int i = 0; i < barrel; i++)
            {

                if (bar == pos.Length) bar = 0;
                rng = Random.RandomRange(1, sigma);
                float realRng = Random.RandomRange(dispersion * 0.1f, dispersion / rng);
                GameObject objProjectile = GameObject.Instantiate<GameObject>(atkEffectPrefab, pos[i].transform.position, Quaternion.identity);
                    //* Quaternion.Euler(target.transform.position.x - transform.position.x, bar * realRng, target.transform.position.z -  transform.position.z));

                //Vector3 l_vector = target.transform.position - transform.position;
                //Quaternion ro = Quaternion.LookRotation(l_vector).normalized; //position���� ����
                //objProjectile.transform.forward = transform.forward; //������ �θ��� forward�� ����. �� �����ΰ�
                //objProjectile.transform.rotation = ro;

                //소환하고 나서 그후 바꿔줘도 되겠네
                bar++;
                float x = Random.Range(target.transform.position.x - 1f * realRng * 0.5f, target.transform.position.x + 1f * realRng * 0.5f);
                float z = Random.Range(target.transform.position.z - 1f * realRng * 0.5f, target.transform.position.z + 1f * realRng * 0.5f);

                Vector3 vec = new Vector3(x, target.transform.position.y, z); //쏘는 방향벡터를 저장

                if(isDamageAround)
                {
                    Main410mmProejctilAtk projectileMain = objProjectile.GetComponent<Main410mmProejctilAtk>();

                    if (projectileMain != null)
                    {
                        projectileMain.projectileParents = this.gameObject;  //�θ� ����� 
                        projectileMain.target = target;
                        projectileMain.attackBehaviour = this;


                    }

                    projectileMain.transform.LookAt(vec);

                    projectileMain.InstanceDamageAround(vec);
                }
                else
                {
                    CollisionProjectileAtk projectile = objProjectile.GetComponent<CollisionProjectileAtk>();


                    if (projectile != null)
                    {
                        projectile.projectileParents = this.gameObject;  //�θ� ����� 
                        projectile.target = target;
                        projectile.attackBehaviour = this;


                    }


                    projectile.transform.LookAt(vec);

                }
                 //�������� �̰� ������ �̝��� �ϰ�
                                                                                                          //bulletMove���� CollisionprojectilAtk�� ��Ӿȹ����ϱ� �ù�
             
            }




           

        }


        //타겟의 위치에 범위 그리기

        nowAtkCoolTime = 0.0f;
    }




}