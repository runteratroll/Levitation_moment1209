using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateIdleBattery : State<MonsterFSM>
{
    private Animator animator;

    //protected int hashMove = Animator.StringToHash("Move");
    //protected int hashMoveSpd = Animator.StringToHash("MoveSpd");

    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        //애니메이터 문제? 하지만 applay root motion했다고
    }

    public override void OnStart()
    {
        // animator?.SetBool(hashMove, false); 
        //animator.SetFloat(hashMoveSpd, 0); 

    }

    public override void OnUpdate(float deltaTime)
    {

        Debug.Log("stateMachineClass.target = " + stateMachineClass.target);
        if (stateMachineClass.target )
        {


            Debug.Log(stateMachineClass.getFlagAtk);
            if (stateMachineClass.getFlagAtk )
            {
                Debug.Log("공격공격");
                stateMachine.ChangeState<stateAtkBattery>();
            }
          
        }
    }

    public override void OnEnd()
    {
    }
}
