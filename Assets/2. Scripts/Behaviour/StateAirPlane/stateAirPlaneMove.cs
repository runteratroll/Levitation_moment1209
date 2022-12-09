using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.AI;

public class stateAirPlaneMove : State<MonsterFSM>
{
    private Animator animator;
    private Rigidbody rigidbody;
   

    private int hashMove = Animator.StringToHash("Move");
    private int hashMoveSpeed = Animator.StringToHash("MoveSpd");


    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        rigidbody = stateMachineClass.GetComponent<Rigidbody>();

    }
    Transform target;

    public override void OnStart()
    {
        
        animator?.SetBool(hashMove, true);

    }
    Vector3 dir;
    public override void OnUpdate(float deltaTime)
    {
        //발건하면 플레이어쪽으로 회전이동하고, forward로 움직인다음, atkRange에 있다면, 쏘고나서 

        target = stateMachineClass.SearchMonster();

        Debug.Log("stateMachineClass.getFlagAtk : " + stateMachineClass.getFlagAtk);
        if (target && !stateMachineClass.getFlagAtk)
        {
    

            dir = target.transform.position - stateMachineClass.transform.position;

            dir.y += 0.5f;

            rigidbody.velocity = dir * Time.deltaTime * 100f;


            //float distance = Vector3.Distance(target.transform.position, stateMachineClass.transform.position);

            //빈오브젝트 만들어가지고 뺀거를 
            //float stopDis = Vector3.Distance(target.transform.position, transform.position);
          
             return;
        }
        else if(target && stateMachineClass.getFlagAtk)
        {
            stateMachine.ChangeState<stateAirPlaneAtk>();

            return;
        }
        stateMachine.ChangeState<stateAirPlaneIdle>();
    }

    public override void OnEnd()
    {
        animator?.SetBool(hashMove, false);
        animator?.SetFloat(hashMoveSpeed, 0);
        rigidbody.velocity = Vector3.zero; //아무곳도 안하는 거겠지?
    }
}