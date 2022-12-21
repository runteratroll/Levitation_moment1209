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
            //������ ó�� ���� 
            return;
        }



        //�� �׾��ٸ�, ���� hp���� �������� ���� ���ش� 
        currentHealth -= dmg;
        //healthSystem.Damage(dmg);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }

        hpManager.DmgHealth();

        //if (atkEffectPrefab)
        //{
        //    Instantiate(atkEffectPrefab, weaponHitTransform); //������ �ً�, ����Ʈ����Ʈ�� �ֳ�
        //    //weaponHitTransform��  ������ Ŭ���� ���� �ʿ� �߰��ϰ� ���ƿ´�
        //    //Į�� �¾Ҵ� �� �� Į�� ��ġ
        //    //���� ���� 
        //}

        //������ ���� �ϰ� 0 ���ϰ� �Ǹ� ���� ���°� �ǰ���
        //�ٵ� ������ �����ص� ��� �ִ� ���¸� 
        if (getFlagLive)
        {

        }
        else
        {
            //���� ���¸� stateDie�� ���� ��ȯ 
            //fsmManager.ChangeState<stateDie>(); //
            Die();
        }
    }



}
