using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateShipIdle : State<MonsterFSM>
{
    private Animator animator;
    private BoxCollider boxController;

    //protected int hashMove = Animator.StringToHash("Move");
    //protected int hashMoveSpd = Animator.StringToHash("MoveSpd");

    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        boxController = stateMachineClass.GetComponent<BoxCollider>();
    }

    public override void OnStart()
    {
        // animator?.SetBool(hashMove, false); 
        //animator.SetFloat(hashMoveSpd, 0); 

    }

    public override void OnUpdate(float deltaTime)
    {
        if (stateMachineClass.target)
        {
            
                //�̰Ÿ� ���� �����ؾ� �Ǵ±���
                //stateHampo�̷���
                stateMachine.ChangeState<stateShipMove>();
            
        }
    }

    public override void OnEnd()
    {
    }
}
