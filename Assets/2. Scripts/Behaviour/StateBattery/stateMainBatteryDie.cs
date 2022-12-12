using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateMainBatteryDie : State<MonsterFSM>
{
    private Animator animator;
    protected int flagLive = Animator.StringToHash("flagLive");

    private GameObject explosion;
    private ShipEnemy shipHealth;
    private GameObject fireSomok;
    private float dmg;


    private bool isExplosion;

    public stateMainBatteryDie(GameObject effecf = null, ShipEnemy shipEnemy = null, float dieDamage  = 0f, GameObject fireSmoke = null)
    {
        explosion = effecf;
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

        GameObject.Instantiate(fireSomok, stateMachineClass.transform.position, Quaternion.identity);
    }

    public override void OnUpdate(float deltaTime)
    {

        //플레이어 Hp가 0이면
        if (stateMachine.getStateDurationTime > 3.0f && !isExplosion)
        {
            isExplosion = true;
            GameObject.Instantiate(explosion, stateMachineClass.transform.position, Quaternion.identity);
            shipHealth.shipHealth -= dmg;
           // GameObject.Destroy(stateMachineClass.gameObject);
        }
    }

    public override void OnEnd() {
    
        
        //공격중지하기
    }
}
