using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryBattery : MonsterFSM_Behaviour
{


    //������ �������� ȭ�� ��鸮��

    public GameObject healthBar;
    public ShipEnemy shipEnemy;
    public GameObject explosionEffect;
    public GameObject fireSmoke;
    private void Awake()
    {
        shipEnemy = transform.root.gameObject.GetComponent<ShipEnemy>();
        
        hp = maxHp;
    }

    // Start is called before the first frame update
    protected override void Start()
    {

        //Debug.Log("�������� ���͸�");
        fsmManager = new StateMachine<MonsterFSM>(this, new stateIdleBattery());
        fsmManager.AddStateList(new stateAtkBattery());
        fsmManager.AddStateList(new stateMainBatteryDie( shipEnemy,10000f , fireSmoke));

        OnAwakeAtkBehaviour();

        atkRange = nowAtkBehaviour?.atkRange ?? 5.0f;
   

        

        healthSystem = new HealthSystem(maxHp);
        GameObject newHealthBar = Instantiate(healthBar, new Vector3(transform.GetChild(0).position.x , transform.GetChild(0).position.y, transform.GetChild(0).position.z ), Quaternion.identity);
        newHealthBar.transform.SetParent(transform.GetChild(0));
        newHealthBar.GetComponent<HealthBar>().Setup(healthSystem);

        newHealthBar.transform.localPosition = Vector3.zero;


        newHealthBar.transform.localPosition = new Vector3(0, 0.0171f, 0.03f);


    }


 
    public override void OnExecuteAttack(int attackIndex)
    {
        if(getFlagLive) //����������� �����ϱ�
        {
            base.OnExecuteAttack(attackIndex);
        }
      
    }

    public override void setDmg(int dmg, GameObject atkEffectPrefab)
    {
        Debug.Log("�µ�����");
        //�׾��� ?
        if (!getFlagLive)
        {
            //������ ó�� ���� 
            return;
        }


        hp -= dmg;
        if(hp <= 0) //-�� �ȵǰ� �ϰ� 
        {

            //
            hp = 0;
        }


        healthSystem.Damage(dmg);


        if (atkEffectPrefab)
        {
            Instantiate(atkEffectPrefab, weaponHitTransform); //������ �ً�, ����Ʈ����Ʈ�� �ֳ�
        }

        //������ ���� �ϰ� 0 ���ϰ� �Ǹ� ���� ���°� �ǰ���
        //�ٵ� ������ �����ص� ��� �ִ� ���¸� 
        if (getFlagLive)
        {
            //animator?.SetTrigger("hitTriggerHash"); /�´� �ִϸ��̼�
        }
        else
        {
            
            //
            //�´� �Ҹ�
            //�´� ����Ʈ �ֱ�

            //���� ���¸� stateDie�� ���� ��ȯ 
            fsmManager.ChangeState<stateMainBatteryDie>(); //

        }
    }
    protected override void Update()
    {
        OnCheckAtkBehaviour();
        base.Update();

    }





}
