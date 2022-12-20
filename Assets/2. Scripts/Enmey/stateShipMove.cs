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


    private float speed;


    public stateShipMove(float _shipSpeed)
    {
        speed = _shipSpeed;
    }
    private rotationColliderCheck rotationColliderCheck;
    public override void OnAwake()
    {

        //animator = stateMachineClass.GetComponent<Animator>();
        rotationColliderCheck = stateMachineClass.GetComponentInChildren<rotationColliderCheck>();
    }

    public override void OnStart()
    {
        

        //agent?.SetDestination(stateMachineClass.transform.position + stateMachineClass.baseTarget.position);
        //animator?.SetBool(hashMove, true);
       
    }

    public override void OnUpdate(float deltaTime)
    {

        try
        {
            stateMachineClass.transform.rotation = rotationColliderCheck.rotShipEnemy();
        }
        catch
        {
            Debug.LogWarning("rotationCheck스크립트를 붙이세요");
        }
     

        stateMachineClass.transform.Translate(stateMachineClass.transform.forward * Time.deltaTime  * speed);




    }

    public override void OnEnd()
    {
        //animator?.SetBool(hashMove, false);
        //animator?.SetFloat(hashMoveSpeed, 0);
    }
}
