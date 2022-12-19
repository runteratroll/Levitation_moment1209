using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionProjectileAtk : MonoBehaviour
{
    public float projectileSpd;
    public GameObject ObjProjectileStartEffect;
    public GameObject ObjProjectileHitEffect;
    public AudioClip projectileStartClip;
    public AudioClip projectileHitClip;
    protected bool getFlagProjectileCollid;
    protected Rigidbody rigidbody;

    public bool isTorpedo = false;

    public int damage;
    [HideInInspector]
    public AtkBehaviour attackBehaviour; //리스트는 아니니까 이거 왜있는겨 이거 선생님한테 물어보자


    [HideInInspector]
    public GameObject projectileParents;

    //발사체의 대상의 초기위치를 잡기 위해 캐싱 

    public GameObject target;
    //foc를 써야되

    //발사체 초기화 
    protected virtual void Start()
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
            Vector3 vecProjectile = target.transform.position;
            vecProjectile.y += 0.9f;
            transform.LookAt(vecProjectile);
        }
    }

    protected virtual void FixedUpdate()
    {
        if (isTorpedo)
        {
            float y = Mathf.Clamp(transform.position.y, -0.2819754f, 10f);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z);
        }
        if (projectileSpd != 0 && rigidbody != null)
        {
            rigidbody.position += (transform.forward) * (projectileSpd * Time.deltaTime);
            //transform.Translate(Vector3.forward * Time.deltaTime * projectileSpd);
        }
    }
    //이것도 부모구나 이것도 이제 다르게 하는구나




    protected virtual void OnProjectileStartCollision(Collider other)
    {
        Debug.Log(getFlagProjectileCollid);
        if (getFlagProjectileCollid)
        {
            return;
        }

        Collider projectileCollider = GetComponent<Collider>();

        projectileCollider.enabled = false;

        getFlagProjectileCollid = true;

        if (projectileHitClip != null && GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().PlayOneShot(projectileHitClip);
        }

        projectileSpd = 0;
        rigidbody.isKinematic = true;

        //ContactPoint contactPoint = collision.contacts[0];

        //Quaternion rotationContact = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
        //Vector3 vecContact = contactPoint.point;

        if (ObjProjectileHitEffect != null)
        {
            var projectileHitEffect = Instantiate(ObjProjectileHitEffect, other.transform.position, Quaternion.identity) as GameObject;

            ParticleSystem particleSystem = projectileHitEffect.GetComponent<ParticleSystem>();
            if (particleSystem == null)
            {
                ParticleSystem particleSystemChild = projectileHitEffect.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(projectileHitEffect, particleSystemChild.main.duration);
            }
            else
            {
                Destroy(projectileHitEffect, particleSystem.main.duration);
            }
        }

        IDmgAble iDmgAble = other.gameObject.GetComponent<IDmgAble>();

        if (iDmgAble != null)
        {
            //Debug.Log("히히 데미지");
            iDmgAble.setDmg(damage, null); //atk 데미지 할 필요없지?

            if (other.CompareTag("Player"))
            {
                DamagePopup.Create(other.transform.position, damage, false, true);
            }
            else
                DamagePopup.Create(other.transform.position, damage, false);
            //그러네 플레이어는 MonsterFsm에 attackBehaviour가 없었잖아 그러니 그렇지 0이니까 안바뀐거였어
        }

        StartCoroutine(DestroyParticle(0.0f));
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Base"))
        {
            OnProjectileStartCollision(other);
        }



        //if((1 << LayerMask) & other.gameObject.layer > 0)
        //{

        //}

    }

    public IEnumerator DestroyParticle(float waittingTime)
    {
        if (transform.childCount > 0 && waittingTime != 0)
        {
            List<Transform> destoryParticleTopChilds = new List<Transform>();
            foreach (Transform t in transform.GetChild(0).transform)
            {
                destoryParticleTopChilds.Add(t);
            }

            while (transform.GetChild(0).localScale.x > 0)
            {
                yield return new WaitForSeconds(0.01f);
                transform.GetChild(0).localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                for (int i = 0; i < destoryParticleTopChilds.Count; i++)
                {
                    destoryParticleTopChilds[i].localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                }
            }
        }

        yield return new WaitForSeconds(waittingTime);

        Destroy(gameObject);
    }
}