using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateShipIdle : State<MonsterFSM>
{
    private Animator animator;

    //protected int hashMove = Animator.StringToHash("Move");
    //protected int hashMoveSpd = Animator.StringToHash("MoveSpd");

    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
    }

    public override void OnStart()
    {
        // animator?.SetBool(hashMove, false); 
        //animator.SetFloat(hashMoveSpd, 0); 

    }

    public override void OnUpdate(float deltaTime)
    {
        Debug.Log("State�� �̵�����");
        stateMachine.ChangeState<stateShipMove>();
        if (stateMachineClass.target)
        {

            //�̰Ÿ� ���� �����ؾ� �Ǵ±���
            //stateHampo�̷���
        
                
            
        }
    }

    public override void OnEnd()
    {
    }
}
