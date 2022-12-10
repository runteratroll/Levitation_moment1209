using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTypeAtkBehaviour : AtkBehaviour
{

    public AudioSource audioSource;
    public ParticleSystem particle;
    public float pitch;
    public override void callAtkMotion(GameObject target = null, Transform posAtkStart = null)
    {
        if (target == null && posAtkStart != null) //Ÿ���� ����, �߻���ġ����
        {
            return;
        }
        //Ÿ���� �����ִ� �Ű��� 


        if(audioSource!= null)
        {
            pitch = Random.RandomRange(0.8f, 1.2f);
            audioSource.pitch = pitch;



            audioSource.Play();
        }
        
        if(particle != null)
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
            Quaternion ro =  Quaternion.LookRotation(l_vector).normalized; //position���� ����
            objProjectile.transform.forward = transform.forward ; //������ �θ��� forward�� ����. �� �����ΰ�
            objProjectile.transform.rotation = ro;

            
            CollisionProjectileAtk projectile = objProjectile.GetComponent<CollisionProjectileAtk>(); //�������� �̰� ������ �̝��� �ϰ�
            //bulletMove���� CollisionprojectilAtk�� ��Ӿȹ����ϱ� �ù�
  
            if (projectile != null)
            {
                projectile.projectileParents = this.gameObject;  //�θ� ����� 
                projectile.target = target; 
                projectile.attackBehaviour = this;
            }
        }

        nowAtkCoolTime = 0.0f;
    }
}