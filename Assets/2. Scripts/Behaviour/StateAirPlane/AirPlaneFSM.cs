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



        OnAwakeAtkBehaviour(); //그래서 MonsterFSM_Behaviour atakeBehaviour

        atkRange = nowAtkBehaviour?.atkRange ?? 5.0f; //

        healthSystem = new HealthSystem(maxHp);

        healthBar.Setup(healthSystem);




        //
    }

    public override void OnExecuteAttack(int attackIndex) //FSM이라 그런지 여기에 공격이있네
    {
        if (getFlagLive) //살아있을때만 공격 //이미 있을거 같긴한데
        {
            base.OnExecuteAttack(attackIndex);
        }

    }

    public override void setDmg(int dmg, GameObject atkEffectPrefab)
    {
        Debug.Log("셋데미지");
        //죽었냐 ?
        if (!getFlagLive)
        {
            //데미지 처리 안함 
            return;
        }


        hp -= dmg;
        healthSystem.Damage(dmg);
        if (hp <= 0) //-가 안되게 하고 
        {
            hp = 0;
        }





        if (atkEffectPrefab)
        {
            Instantiate(atkEffectPrefab, weaponHitTransform); //데미지 줄떄, 어펙트이펙트도 주네
        }

        //데미지 차감 하고 0 이하가 되면 죽은 상태가 되겠지
        //근데 데미지 차감해도 살아 있는 상태면 
        if (getFlagLive)
        {
            //animator?.SetTrigger("hitTriggerHash"); /맞는 애니메이션
        }
        else
        {

            //
            //맞는 소리
            //맞는 이펙트 넣기

            //죽은 상태면 stateDie로 상태 전환 
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
