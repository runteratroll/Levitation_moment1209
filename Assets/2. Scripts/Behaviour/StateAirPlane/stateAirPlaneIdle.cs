using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateAirPlaneIdle : State<MonsterFSM>
{

    private Animator animator;
    private Rigidbody rigid;
    //State자체에 애니메이션이 있구나


    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        //애니메이터 문제? 하지만 applay root motion했다고
        rigid = stateMachineClass.GetComponent<Rigidbody>();
    }

    public override void OnStart()
    {
        animator?.SetBool(hashMove, false); 
        animator.SetFloat(hashMoveSpd, 0);
        rigid.velocity = Vector3.zero;
    }
    protected int hashMove = Animator.StringToHash("Move");
    protected int hashMoveSpd = Animator.StringToHash("MoveSpd");
    public override void OnUpdate(float deltaTime)
    {
        rigid.velocity = stateMachineClass.transform.forward  * 30f;

        Debug.Log("되니?");
        Debug.Log("되니앞에는 target이 있는지 체크");
        if (stateMachineClass.target)
        {
            Debug.Log(stateMachineClass.getFlagAtk);
            if (stateMachineClass.getFlagAtk) //적과의 거리가 atkRange보다 짧다면
            {
                stateMachine.ChangeState<stateAirPlaneAtk>();
            }
            else
            {

                Debug.Log("이동스테이트");
                
                stateMachine.ChangeState<stateAirPlaneMove>(); // 타겟을 발견하면 플레이어한테 이동하기
            }
        }

        
    }
  
}
