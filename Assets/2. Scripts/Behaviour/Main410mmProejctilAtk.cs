using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main410mmProejctilAtk : CollisionProjectileAtk
{

    public GameObject damageAround;

    private GameObject damageObj;

    private int range;
    private int idx;



    protected override void Start()
    {
        getFlagProjectileCollid = false;
        rigidbody = GetComponent<Rigidbody>();
        //그냥 target도 있으니까 

        //그냥 데미지만 넣어도 괜찮을 거같소
        //만약 소유자가 있다면 
        if (projectileParents != null)
        {
            Collider collidProjectile = GetComponent<Collider>();
            Collider[] collidParents = projectileParents.GetComponentsInChildren<Collider>();
            foreach (Collider collider in collidParents)
            {
                Physics.IgnoreCollision(collidProjectile, collider);
            }
        }


        if (ObjProjectileStartEffect != null)
        {
            var projectileStartEffect = Instantiate(this.ObjProjectileStartEffect, transform.position, Quaternion.identity);



            projectileStartEffect.transform.forward = gameObject.transform.forward;

            ParticleSystem particleSystem = projectileStartEffect.GetComponent<ParticleSystem>();

            if (particleSystem != null)
            {
                Destroy(projectileStartEffect, particleSystem.main.duration * 20);
            }
            else
            {
                ParticleSystem particleSystemChild = projectileStartEffect.transform.GetChild(0).GetComponent<ParticleSystem>();

                Destroy(projectileStartEffect, particleSystemChild.main.duration * 20);
            }
        }


        //사운드 관련부분
        if (projectileStartClip != null && GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().PlayOneShot(projectileStartClip);
        }


        //타겟이 플레이어라면, 발사체가 바라보는 방향을 타겟으로 한다. 이걸 업데이트로 하면은 유도탄같은 개념인가
        if (target != null)
        {
            //Vector3 vecProjectile = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
            ////vecProjectile.y += 0.9f;




            //transform.LookAt(vecProjectile);
        }

        



    }


    public void InstanceDamageAround(Vector3 tagetRandom)
    {
        Debug.Log("소환되니?");
        damageObj = Instantiate(damageAround);

        damageObj.transform.position = new Vector3(tagetRandom.x, tagetRandom.y * 1.2f, tagetRandom.z); //��ȯ�ǰ�
        damageObj.transform.localScale = new Vector3(damageObj.transform.localScale.x, 0.01f, damageObj.transform.localScale.z);

        //랜덤 레인지 
        range = Random.Range(0, 3000000);

        idx = range;



    }



    protected override void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("DamageAround") && idx == range)
        {
            
            //가끔가다 //여기오류나는 이유가 다른 DamageAround를 만나가지고 없어져서 그렇네

            if(damageObj != null)
            {

                DamageAroundfor damageAroundfor = damageObj?.GetComponent<DamageAroundfor>();
                damageAroundfor.DamageBulletHit(damage, true);
            }






        }
    }

}
