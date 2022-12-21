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

    private ShipEnemy shipEnemy;

    private float speed;

    

    public stateShipMove(float _shipSpeed)
    {
        speed = _shipSpeed;
    }
    private rotationColliderCheck rotationColliderCheck;
    public override void OnAwake()
    {
        shipEnemy = stateMachineClass.GetComponent<ShipEnemy>();
        //Target = GameObject.FindObjectOfType<militarybaseHealth>().transform;
        //animator = stateMachineClass.GetComponent<Animator>();
        //agent = stateMachineClass.GetComponent<NavMeshAgent>();
        rotationColliderCheck = stateMachineClass.GetComponent<rotationColliderCheck>();
    }

    public override void OnStart()
    {
        

        //agent?.SetDestination(Target.position);
        //animator?.SetBool(hashMove, true);
       
    }

    public override void OnUpdate(float deltaTime)
    {

        try
        {
            if(shipEnemy.isMove == true)
            stateMachineClass.transform.rotation = rotationColliderCheck.rotShipEnemy(); //월드 기준으로 회전
        }
        catch
        {
            Debug.LogWarning("rotationCheck스크립트를 붙이세요");
        }



        if (shipEnemy.isMove == true)
            stateMachineClass.transform.Translate(Vector3.forward * Time.deltaTime * speed * 50); //로컬로 변환해주나?
            
    


    }

    public override void OnEnd()
    {
        //animator?.SetBool(hashMove, false);
        //animator?.SetFloat(hashMoveSpeed, 0);
    }
}
