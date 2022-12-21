using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class militarybaseHealth : LivingEntity {

    static int dieCount;


    private BoxCollider boxCollider;
    public ParticleSystem ExplosionBase;

    private SpriteRenderer spriteRenderer;

    public BaeHpManager hpManager;
    protected override void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();



    }
    private void Awake()
    {
        dieCount = 0;
        boxCollider = GetComponent<BoxCollider>();

        //hpManager = FindObjectOfType<BaeHpManager>();
    }
    public override void Die()
    {
        if (dead == true)
            return;
        spriteRenderer.enabled = false;
        dead = true;
        boxCollider.enabled = false;
        dieCount++;

        ExplosionBase.Play();





        Invoke("ExplodeDelay", 3f);
        //if(BaseManager.Instance != null)
        //{
        //    BaseManager.Instance.MilitaryBaseCheck(this);
        //}
        //else
        //{

        //    BaseManager.Instance?.MilitaryBaseCheck(this);
        //}
        
    }

    void ExplodeDelay()
    {
        if (dieCount >= 3)
        {
            SceneManager.LoadScene("DieScene");
        }
    }

    public override void setDmg(int dmg, GameObject prefabEffect)
    {

        if (!getFlagLive)
        {
            //데미지 처리 안함 
            return;
        }



        //안 죽었다면, 현재 hp에서 데미지를 차감 해준다 
        currentHealth -= dmg;
        //healthSystem.Damage(dmg);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }

        hpManager.DmgHealth();

        //if (atkEffectPrefab)
        //{
        //    Instantiate(atkEffectPrefab, weaponHitTransform); //데미지 줄떄, 어펙트이펙트도 주네
        //    //weaponHitTransform는  변수를 클래스 변수 쪽에 추가하고 돌아온다
        //    //칼을 맞았다 할 때 칼의 위치
        //    //힙을 설정 
        //}

        //데미지 차감 하고 0 이하가 되면 죽은 상태가 되겠지
        //근데 데미지 차감해도 살아 있는 상태면 
        if (getFlagLive)
        {

        }
        else
        {
            //죽은 상태면 stateDie로 상태 전환 
            //fsmManager.ChangeState<stateDie>(); //
            Die();
        }
    }



}
