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
        Debug.Log("State를 이동으로");
        stateMachine.ChangeState<stateShipMove>();
        if (stateMachineClass.target)
        {

            //이거를 이제 조정해야 되는구만
            //stateHampo이렇게
        
                
            
        }
    }

    public override void OnEnd()
    {
    }
}
