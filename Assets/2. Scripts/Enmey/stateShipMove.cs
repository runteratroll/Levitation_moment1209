using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class stateShipMove : State<MonsterFSM> //������ ��FSM���� �ٲٰ͵� �����ؾ߰ڴ�.
{
    //private Animator animator;
    private NavMeshAgent agent;

    private int hashMove = Animator.StringToHash("Move");
    private int hashMoveSpeed = Animator.StringToHash("MoveSpd");

    

    public override void OnAwake()
    {

        //animator = stateMachineClass.GetComponent<Animator>();

    }

    public override void OnStart()
    {
        

        agent?.SetDestination(stateMachineClass.transform.position + stateMachineClass.baseTarget.position);
        //animator?.SetBool(hashMove, true);
       
    }

    public override void OnUpdate(float deltaTime)
    {

      
            stateMachineClass.transform.Translate(stateMachineClass.transform.right * Time.deltaTime * -1 * -1);

    }

    public override void OnEnd()
    {
        //animator?.SetBool(hashMove, false);
        //animator?.SetFloat(hashMoveSpeed, 0);
    }
}
