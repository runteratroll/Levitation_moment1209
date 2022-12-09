using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneFSM : MonsterFSM_Behaviour
{
    public HealthBar healthBar;
    public Transform stopDistCheck;

    private void Awake()
    {
        hp = maxHp;
    }

    protected override void Start()
    {
        fsmManager = new StateMachine<MonsterFSM>(this, new stateAirPlaneIdle());
        fsmManager.AddStateList(new stateAirPlaneAtk());
        fsmManager.AddStateList(new stateAirPlaneDie());
        fsmManager.AddStateList(new stateAirPlaneMove());
        fsmManager.AddStateList(new stateAirPlaneExit());



        OnAwakeAtkBehaviour(); //�׷��� MonsterFSM_Behaviour atakeBehaviour

        atkRange = nowAtkBehaviour?.atkRange ?? 5.0f; //

        healthSystem = new HealthSystem(maxHp);

        healthBar.Setup(healthSystem);




        //
    }

    public override void OnExecuteAttack(int attackIndex) //FSM�̶� �׷��� ���⿡ �������ֳ�
    {
        if (getFlagLive) //����������� ���� //�̹� ������ �����ѵ�
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
        healthSystem.Damage(dmg);
        if (hp <= 0) //-�� �ȵǰ� �ϰ� 
        {
            hp = 0;
        }





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
            fsmManager.ChangeState<stateAirPlaneDie>(); //

        }
    }
    protected override void Update()
    {

        Debug.Log(fsmManager.getNowState);
        OnCheckAtkBehaviour();
        base.Update();

    }

}
