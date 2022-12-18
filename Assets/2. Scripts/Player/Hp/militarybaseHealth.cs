using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class militarybaseHealth : LivingEntity {

    static int dieCount;


    private void Awake()
    {
        dieCount = 0;
    }
    public override void Die()
    {
        dieCount++;

        if(dieCount >= 2)
        {
            SceneManager.LoadScene("SeungHoon2");
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
        hpBar.hp -= (float)dmg; //���� �����ϰ� �ִ� HpBar�� Hp�� ���δ�. 
        //healthSystem.Damage(dmg);



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
