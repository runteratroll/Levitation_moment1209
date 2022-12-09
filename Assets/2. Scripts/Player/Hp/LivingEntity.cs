using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDmgAble
{
    
    [SerializeField] protected int maxHealth;
    
    
    //HealthSystem healthSystem;
    [SerializeField]
    protected int currentHealth;
    protected bool dead;

    public bool getFlagLive => currentHealth > 0;
    public HpBar hpBar;


    protected virtual void Start()
    {
        currentHealth = (int)hpBar.maxHp;
        
    }


    public virtual void Die()
    {
        dead = true;
        Debug.Log("����");
    }

    public virtual void setDmg(int dmg, GameObject prefabEffect)
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
