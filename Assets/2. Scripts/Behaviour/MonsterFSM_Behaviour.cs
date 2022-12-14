using System.Collections.Generic;
using UnityEngine;

public class MonsterFSM_Behaviour : MonsterFSM, IAtkAble, IDmgAble
{
    [SerializeField]
    protected List<AtkBehaviour> attackBehaviours = new List<AtkBehaviour>();

    public AtkBehaviour nowAtkBehaviour //setDamage를
    {
        get;
        private set;
    }

    public float maxHp = 100;

    public float hp;
    //public int Hp
    //{
    //    get ;
    //    private set;
    //}

    public bool getFlagLive => hp > 0;
    public LayerMask targetLayerMask;
    public Collider atkItemCollider;

    protected GameObject atkEffectPrefab = null;

    public Transform launchWeaponTransform;
    public Transform weaponHitTransform;

    protected HealthSystem healthSystem;


    protected override void Start()
    {
        base.Start();



        fsmManager.AddStateList(new stateMove());
        fsmManager.AddStateList(new stateAtk());
        fsmManager.AddStateList(new stateDie());

        OnAwakeAtkBehaviour();

        atkRange = nowAtkBehaviour?.atkRange ?? 5.0f;


    }

    protected override void Update()
    {
        OnCheckAtkBehaviour();
        base.Update();
    }


    public override bool getFlagAtk
    {
        get
        {
            if (!target)
            {
                return false;
            }

            float distance = Vector3.Distance(transform.position, target.position);
            //Debug.Log("distance : " + distance + ">>>>>> atkRange" + atkRange);
            return (distance <= atkRange);
        }
    }

    public J ChangeState<J>() where J : State<MonsterFSM>
    {
        return fsmManager.ChangeState<J>();
    }

    override public Transform SearchMonster()
    {
        return base.target;
    }


    //근데 공격을 여기서 하네
    public virtual void OnExecuteAttack(int attackIndex)
    {

        //Debug.Log("발사");
        if (nowAtkBehaviour != null && target != null)
        {
            if(launchWeaponTransform != null)
            nowAtkBehaviour.callAtkMotion(target.gameObject, launchWeaponTransform);
            else{
                  nowAtkBehaviour.callAtkMotion(target.gameObject, transform);
            }
        }
    }

    protected void OnAwakeAtkBehaviour()
    {
        foreach (AtkBehaviour behaviour in attackBehaviours)
        {
            if (nowAtkBehaviour == null)
            {
                nowAtkBehaviour = behaviour;
            }

            behaviour.targetLayerMask = targetLayerMask;
        }
    }

    protected void OnCheckAtkBehaviour()
    {
        if (nowAtkBehaviour == null || !nowAtkBehaviour.IsAvailable) //공격이 불가능하면 
        {
            //현재 공격함수가 공격불가능하면
            nowAtkBehaviour = null;

            foreach (AtkBehaviour behaviour in attackBehaviours)
            {
                //다른 클래스훓다가 
                if (behaviour.IsAvailable) //공격가능하면
                {

                    // now가 널이고, 현재 중요도가 다른 behaviour보다 적다면
                    if ((nowAtkBehaviour == null) || (nowAtkBehaviour.importanceAtkNo < behaviour.importanceAtkNo)) //이게 중요도구나 //숫자가 제일낮은거부터 실행
                    {
                        nowAtkBehaviour = behaviour;
                        Debug.Log(nowAtkBehaviour.name);
                    }
                }
            }
        }
    }




    //5. 공격을 직접적으로 받았을 때   이제 helth로 판정 하면 된다 
    public virtual void setDmg(int dmg, GameObject atkEffectPrefab)
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
            //죽은 상태면 stateDie로 상태 전환 
            fsmManager.ChangeState<stateDie>(); //
        }
    }

}
