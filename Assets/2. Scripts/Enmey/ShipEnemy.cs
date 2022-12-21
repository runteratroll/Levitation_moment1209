using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipEnemy : MonsterFSM_Behaviour
{

    //public SecondaryBattery[] secondaryBatterys;
    //public MainBattery[] mainBatteries;

    public ShipEnemyHealthBar shipEnemyHealthBar;

    public militarybaseHealth militarybase;
    //public float stopRange = 5f;
    //public Transform basePosition;

    //[Header("콜라이더매니저 부분")]
    //public float colliderSize = 100;
    //public int colliderArrow;
    //public ColliderManger colliderManger = null;


    //private GameObject coll = null;



    public float shipSpeed = 1f;

    public float shipHealth;

    [Header("콜라이더체크관련")]
    public bool isMove = true;
   

    [Range(0f, 1f)]
    public float rotationSpeed = 0.5f;
    rotationColliderCheck roCheck;
    protected override void Start()
    {

        fsmManager = new StateMachine<MonsterFSM>(this, new stateShipIdle());
        roCheck = GetComponentInChildren<rotationColliderCheck>();
        fsmManager.AddStateList(new stateShipMove(shipSpeed));
        fsmManager.AddStateList(new stateDie());

        //감지되면 모든포의 target이 baseTarget됨
        //OnAwakeAtkBehaviour(); ���� ���ҰŶ�
        GetMaxHpSBattery();
        //atkRange = nowAtkBehaviour?.atkRange ?? 5.0f;
        hp = maxHp; // maxHp�� �ڽĵ��� ���� ���ؾߵ�
                    //�� ���Ҷ����� ��ٷ����ϴµ�


        militarybase = GameObject.FindObjectOfType<militarybaseHealth>();




        //Debug.Log("AgnntewrwerewrwVelocity " + agent.velocity);

        healthSystem = new HealthSystem(maxHp);
        shipEnemyHealthBar?.Setup(healthSystem);

        //�ڽ��� �޸� ��ü�� �ް��ϴ°�...
    }


    Vector3 vec90 = new Vector3(0f, 90f, 0f);
    Quaternion To;
    protected override void Update()
    {

     
        base.Update();
        //float dist = Vector3.Distance(militarybase.transform.position, transform.position);

        if (roCheck.isStop)
        {
            isMove = false;


            //부모로
            Quaternion From = transform.rotation;
           

            switch(roCheck.value) //0에서 2로 만듬
            {
                case 0:
                   To = Quaternion.Euler(0, 57f, 0);
                    break;
                case 1:
                    To = Quaternion.Euler(0, 90f, 0);
                    break;
                case 2:
                    To = Quaternion.Euler(0, 153f, 0);
                    break;
            }


            transform.rotation = Quaternion.Slerp(From, To, 0.5f * Time.deltaTime); 

        }
        else
        {
            isMove = true;
        }
    }

    void GetMaxHpSBattery()
    {
        maxHp = 0;
        //foreach (SecondaryBattery tem in secondaryBatterys)
        //{
        //    maxHp += tem.hp;
        //}
        //foreach (MainBattery tem in mainBatteries)
        //{
        //    maxHp += tem.hp;
        //}

        maxHp += shipHealth;
    }




    public float GetBatteryCurrentHp() //���� �̰� �޾ư����� ������Ʈ �ｺ�� �ϱ�
    {

        //Debug.Log("GetBatter�� ����Ǵ�?");

        //�ٵ��̰� ���ɴʳ�
        float batterysHp = 0;
        //foreach (SecondaryBattery tem in secondaryBatterys)
        //{
        //    if(tem.hp <= 0) //����ü���� 0���� �۰ų� ���ٸ�
        //    {
        //        tem.hp = 0;
        //    }

        //    batterysHp += tem.hp;
        //}
        //foreach(MainBattery tem in mainBatteries)
        //{
        //    if (tem.hp <= 0) //����ü���� 0���� �۰ų� ���ٸ�
        //    {
        //        tem.hp = 0;
        //    }

        //    batterysHp += tem.hp;
        //}
        batterysHp += shipHealth;

        if (batterysHp <= 0)
        {
            shipHealth = 0;
        }

  
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
