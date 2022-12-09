using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateAirPlaneIdle : State<MonsterFSM>
{

    private Animator animator;
    private Rigidbody rigid;
    //State��ü�� �ִϸ��̼��� �ֱ���


    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        //�ִϸ����� ����? ������ applay root motion�ߴٰ�
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

        Debug.Log("�Ǵ�?");
        Debug.Log("�ǴϾտ��� target�� �ִ��� üũ");
        if (stateMachineClass.target)
        {
            Debug.Log(stateMachineClass.getFlagAtk);
            if (stateMachineClass.getFlagAtk) //������ �Ÿ��� atkRange���� ª�ٸ�
            {
                stateMachine.ChangeState<stateAirPlaneAtk>();
            }
            else
            {

                Debug.Log("�̵�������Ʈ");
                
                stateMachine.ChangeState<stateAirPlaneMove>(); // Ÿ���� �߰��ϸ� �÷��̾����� �̵��ϱ�
            }
        }

        
    }
  
}
