using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateShipMove : State<MonsterFSM> //������ ��FSM���� �ٲٰ͵� �����ؾ߰ڴ�.
{
    private Animator animator;
    private BoxCollider boxController;
    private UnityEngine.AI.NavMeshAgent agent;

    private int hashMove = Animator.StringToHash("Move");
    private int hashMoveSpeed = Animator.StringToHash("MoveSpd");

    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        boxController = stateMachineClass.GetComponent<BoxCollider>();

        agent = stateMachineClass.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public override void OnStart()
    {
        agent?.SetDestination(stateMachineClass.target.position);
        animator?.SetBool(hashMove, true);
    }

    public override void OnUpdate(float deltaTime)
    {
        Transform target = stateMachineClass.SearchMonster();
        //Debug.Log("stateMachineClass.getFlagAtk : " + stateMachineClass.getFlagAtk);
        if (target && !stateMachineClass.getFlagAtk)
        {
            agent.SetDestination(stateMachineClass.target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
            {

                boxController.transform.Translate(agent.velocity * Time.deltaTime);
                animator.SetFloat(hashMoveSpeed, agent.velocity.magnitude / agent.speed, 0.1f, Time.deltaTime);
                return;
            }
        }
        stateMachine.ChangeState<stateShipIdle>();
    }

    public override void OnEnd()
    {
        animator?.SetBool(hashMove, false);
        animator?.SetFloat(hashMoveSpeed, 0);
        agent.ResetPath();
    }
}
