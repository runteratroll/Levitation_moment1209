using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateAirPlaneAtk : State<MonsterFSM>
{
    //State�� �ʿ��Ѱ� StateŬ������ �̸� �������߰���?
    private Animator animator; 
    private stateAtkController stateAtkCtrl;
    Rigidbody rigid;
    private IAtkAble iAtkAble;

    protected int atkTriggerHash = Animator.StringToHash("Atk");
    protected int atkIndexHash = Animator.StringToHash("AtkIdx");

    public override void OnAwake()
    {
        //GetComponet�� �ϱ����ؼ� ������ ���ְ�
        animator = stateMachineClass.GetComponent<Animator>();
        stateAtkCtrl = stateMachineClass.GetComponent<stateAtkController>();
        iAtkAble = stateMachineClass.GetComponent<IAtkAble>(); //���� FSM�� IAtkAble�� ��ӹ޾����ϱ� �̰� �Ǵ±���

        rigid = stateMachineClass.GetComponent<Rigidbody>();



    }

    public override void OnStart()
    {
        if (iAtkAble == null || iAtkAble.nowAtkBehaviour == null)
        {
            stateMachine.ChangeState<stateAirPlaneIdle>(); //�׷����ϱ� �̰͵� �ϳ� �����ؾߵǴ�
            return;
        }

        stateAtkCtrl.stateAtkControllerStartHandler += delegateAtkStateStart; //stateAtkCtrl�� �޸�, ���۰� ���� �˸��� �� �� �ֱ���
        stateAtkCtrl.stateAtkControllerEndHandler += delegateAtkStateEnd;

        Debug.Log(iAtkAble.nowAtkBehaviour.aniMotionIdx + ": " + iAtkAble.nowAtkBehaviour.atkRange);

        animator?.SetInteger(atkIndexHash, iAtkAble.nowAtkBehaviour.aniMotionIdx);

        animator?.SetTrigger(atkTriggerHash);



       
    }

    public void delegateAtkStateStart()
    {

        
        UnityEngine.Debug.Log("delegateAtkStateStart()");
    }

    public void delegateAtkStateEnd()
    {
       

        //�������� ���� Ż���ϴ� State
        UnityEngine.Debug.Log("delegateAtkStateEnd()");
        stateMachine.ChangeState<stateAirPlaneExit>();

    }

    public override void OnUpdate(float deltaTime) { }
}
