using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(stateAtkController))]
[RequireComponent(typeof(LookAtPlayer))]
[RequireComponent(typeof(ProjectileTypeAtkBehaviour))]

public class MainBattery : MonsterFSM_Behaviour
{
    public GameObject healthBar;
    private ShipEnemy shipEnemy;
    public float dieDamage;

    public GameObject explosionEffect;
    public GameObject fireSmoke;

    public int colliderAngle = 360;
    public float colliderSize = 100;
    public enum ColliderArrow 
    {
        Front,
        Back
    }
    public ColliderArrow colliderArrow;
    private ColliderManger colliderManger;

    private GameObject coll;
    private void Awake()
    {
        shipEnemy = transform.root.gameObject.GetComponent<ShipEnemy>();
        colliderManger = FindObjectOfType<ColliderManger>();
        colliderAngle = (int)(colliderAngle * 0.1f);
        colliderSize = colliderSize * 0.01f;
        hp = maxHp;

        if(colliderArrow == ColliderArrow.Front)
        {
            coll = Instantiate( colliderManger.fieldofCollidersF[colliderAngle].gameObject, Vector3.zero , Quaternion.identity);
        }
        if(colliderArrow == ColliderArrow.Back)
        {
            coll = Instantiate( colliderManger.fieldofCollidersB[colliderAngle].gameObject, Vector3.zero , Quaternion.identity);
        }

        coll.transform.parent = transform;
        coll.transform.localScale = new Vector3(colliderSize,colliderSize,colliderSize);
        coll.transform.localPosition = new Vector3(0,0,0);
        
        foc = coll.GetComponent<FieldofCollider>();
    }


    //monsterFSM�� �׳� 
    // Start is called before the first frame update
    protected override void Start()
    {
        fsmManager = new StateMachine<MonsterFSM>(this, new stateIdleBattery());
        fsmManager.AddStateList(new stateAtkBattery());
        fsmManager.AddStateList(new stateMainBatteryDie(explosionEffect, shipEnemy, dieDamage, fireSmoke));

        OnAwakeAtkBehaviour();

        atkRange = nowAtkBehaviour?.atkRange ?? 5.0f;




        healthSystem = new HealthSystem(maxHp);
        GameObject newHealthBar = Instantiate(healthBar, new Vector3(transform.GetChild(0).position.x, transform.GetChild(0).position.y, transform.GetChild(0).position.z), Quaternion.identity);
        newHealthBar.transform.SetParent(transform.GetChild(0));
        newHealthBar.GetComponent<HealthBar>().Setup(healthSystem);

        newHealthBar.transform.localPosition = Vector3.zero;


        newHealthBar.transform.localPosition = new Vector3(-0.0468f, 0.0014f, 0.0674f);


    }



    public override void OnExecuteAttack(int attackIndex)
    {
        if (getFlagLive)
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
        if (hp <= 0) //-�� �ȵǰ� �ϰ� 
        {
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
