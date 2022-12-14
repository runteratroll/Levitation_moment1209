using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemy : MonsterFSM_Behaviour
{

    public SecondaryBattery[] secondaryBatterys;
    public MainBattery[] mainBatteries;

    public ShipEnemyHealthBar shipEnemyHealthBar;


    public float shipHealth;
    protected override void Start()
    {

        fsmManager = new StateMachine<MonsterFSM>(this, new stateShipIdle());
        fsmManager.AddStateList(new stateShipMove());
        fsmManager.AddStateList(new stateDie());

        //OnAwakeAtkBehaviour(); ���� ���ҰŶ�
        GetMaxHpSBattery();
        //atkRange = nowAtkBehaviour?.atkRange ?? 5.0f;
        hp = maxHp; // maxHp�� �ڽĵ��� ���� ���ؾߵ�
        //�� ���Ҷ����� ��ٷ����ϴµ�
        healthSystem = new HealthSystem(maxHp);
        shipEnemyHealthBar?.Setup(healthSystem);

        //�ڽ��� �޸� ��ü�� �ް��ϴ°�...
    }
    //�ϴ� ������ ���� ������


    private void Update()
    {
        if(target != null)
        {

        }
    }

    void GetMaxHpSBattery()
    {
        maxHp = 0;
        foreach (SecondaryBattery tem in secondaryBatterys)
        {
            maxHp += tem.hp;
        }
        foreach (MainBattery tem in mainBatteries)
        {
            maxHp += tem.hp;
        }

        maxHp += shipHealth;
    }




    public float GetBatteryCurrentHp() //���� �̰� �޾ư����� ������Ʈ �ｺ�� �ϱ�
    {

        //Debug.Log("GetBatter�� ����Ǵ�?");

        //�ٵ��̰� ���ɴʳ�
        float batterysHp = 0;
        foreach (SecondaryBattery tem in secondaryBatterys)
        {
            if(tem.hp <= 0) //����ü���� 0���� �۰ų� ���ٸ�
            {
                tem.hp = 0;
            }

            batterysHp += tem.hp;
        }
        foreach(MainBattery tem in mainBatteries)
        {
            if (tem.hp <= 0) //����ü���� 0���� �۰ų� ���ٸ�
            {
                tem.hp = 0;
            }

            batterysHp += tem.hp;
        }

        if(batterysHp <= 0)
        {
            shipHealth = 0;
        }

        batterysHp += shipHealth;
        hp = batterysHp;


 
        if (getFlagLive)
        {
            //animator?.SetTrigger("hitTriggerHash"); /�´� �ִϸ��̼�
        }
        else
        {
            //���� ���¸� stateDie�� ���� ��ȯ 
            fsmManager.ChangeState<stateDie>(); //
        }


        return (float)hp / maxHp;
    }

    public override void setDmg(int dmg, GameObject atkEffectPrefab)
    {
        Debug.Log("ShipEnemy������");
        //�׾��� ?
        if (!getFlagLive)
        {
            //������ ó�� ���� 
            return;
        }

        shipHealth -= dmg;

        if( shipHealth <= 0)
        {
            shipHealth = 0;
        }
       // hp -= dmg;
        //healthSystem.Damage(dmg); //�̰͵� �ڵ����� ó�����ִ°ǵ�
        //HealthSystem
        shipEnemyHealthBar.UpdateHealthBar();

        if (atkEffectPrefab)
        {
            Instantiate(atkEffectPrefab, weaponHitTransform); //������ �ً�, ����Ʈ����Ʈ�� �ֳ�
        }

        //������ ���� �ϰ� 0 ���ϰ� �Ǹ� ���� ���°� �ǰ���
        //�ٵ� ������ �����ص� ��� �ִ� ���¸� 
        
    }
}
