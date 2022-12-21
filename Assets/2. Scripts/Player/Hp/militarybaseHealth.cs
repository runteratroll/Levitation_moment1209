using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class militarybaseHealth : LivingEntity {

    static int dieCount;


    private BoxCollider boxCollider;
    protected override void Start()
    {
        currentHealth = maxHealth;
        

    }
    private void Awake()
    {
        dieCount = 0;
        boxCollider = GetComponent<BoxCollider>();
    }
    public override void Die()
    {
        if (dead == true)
            return;

        dead = true;
        boxCollider.enabled = false;
        dieCount++;

        if(dieCount >= 3)
        {
            SceneManager.LoadScene("DieScene");
        }
        //if(BaseManager.Instance != null)
        //{
        //    BaseManager.Instance.MilitaryBaseCheck(this);
        //}
        //else
        //{

        //    BaseManager.Instance?.MilitaryBaseCheck(this);
        //}
        
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
