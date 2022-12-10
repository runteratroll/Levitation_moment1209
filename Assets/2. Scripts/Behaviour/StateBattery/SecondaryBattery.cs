using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryBattery : MonsterFSM_Behaviour
{


    //관찰자 패턴으로 화면 흔들리게

    public GameObject healthBar;
    public ShipEnemy shipEnemy;

    private void Awake()
    {
        shipEnemy = transform.root.gameObject.GetComponent<ShipEnemy>();
        hp = maxHp;
    }

    // Start is called before the first frame update
    protected override void Start()
    {

        //Debug.Log("세컨더리 배터리");
        fsmManager = new StateMachine<MonsterFSM>(this, new stateIdleBattery());
        fsmManager.AddStateList(new stateAtkBattery());
        fsmManager.AddStateList(new stateMainBatteryDie());

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
        if(getFlagLive) //살아있을때만 공격하기
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
        if(hp <= 0) //-가 안되게 하고 
        {

            //
            hp = 0;
        }


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
            shipEnemy.shipHealth -= 10000f;
            //
            //맞는 소리
            //맞는 이펙트 넣기

            //죽은 상태면 stateDie로 상태 전환 
            fsmManager.ChangeState<stateMainBatteryDie>(); //

        }
    }
    protected override void Update()
    {
        OnCheckAtkBehaviour();
        base.Update();

    }





}
