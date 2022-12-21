using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDmgAble
{
    
    public int maxHealth;
    
    
    //HealthSystem healthSystem;
    [SerializeField]
    public int currentHealth;
    public bool dead;

    public bool getFlagLive => currentHealth > 0;
    public HpBar hpBar;


    protected virtual void Start()
    {
      

        currentHealth = (int)hpBar.maxHp;
        
    }

    //3���� ������ �ٽý���
    public virtual void Die()
    {
        //dead = true;


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
