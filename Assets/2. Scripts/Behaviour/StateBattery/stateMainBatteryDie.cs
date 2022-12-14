using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateMainBatteryDie : State<MonsterFSM>
{
    private Animator animator;
    protected int flagLive = Animator.StringToHash("flagLive");

    private ShipEnemy shipHealth;
    private GameObject fireSomok;
    private float dmg;


    private bool isExplosion;

    public stateMainBatteryDie( ShipEnemy shipEnemy = null, float dieDamage  = 0f, GameObject fireSmoke = null)
    {
        shipHealth = shipEnemy;
        dmg = dieDamage;
        fireSomok = fireSmoke;
    }
    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
    }

    public override void OnStart()
    {
        //fire

        animator?.SetBool(flagLive, false);

        GameObject rot =   GameObject.Instantiate(fireSomok, stateMachineClass.transform.position, Quaternion.identity);
        rot.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    public override void OnUpdate(float deltaTime)
    {

        //�÷��̾� Hp�� 0�̸�
        if (stateMachine.getStateDurationTime > 3.0f && !isExplosion)
        {
            isExplosion = true;
            shipHealth.shipHealth -= dmg;
           // GameObject.Destroy(stateMachineClass.gameObject);
        }
    }

    public override void OnEnd() {
    
        
        //���������ϱ�
    }
}
