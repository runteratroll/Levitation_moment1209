using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateAirPlaneAtk : State<MonsterFSM>
{
    //State에 필요한걸 State클래스가 미리 만들어놔야겠지?
    private Animator animator; 
    private stateAtkController stateAtkCtrl;
    Rigidbody rigid;
    private IAtkAble iAtkAble;

    protected int atkTriggerHash = Animator.StringToHash("Atk");
    protected int atkIndexHash = Animator.StringToHash("AtkIdx");

    public override void OnAwake()
    {
        //GetComponet를 하기위해서 저런걸 해주고
        animator = stateMachineClass.GetComponent<Animator>();
        stateAtkCtrl = stateMachineClass.GetComponent<stateAtkController>();
        iAtkAble = stateMachineClass.GetComponent<IAtkAble>(); //몬스터 FSM이 IAtkAble을 상속받았으니까 이게 되는구나

        rigid = stateMachineClass.GetComponent<Rigidbody>();



    }

    public override void OnStart()
    {
        if (iAtkAble == null || iAtkAble.nowAtkBehaviour == null)
        {
            stateMachine.ChangeState<stateAirPlaneIdle>(); //그러고보니까 이것도 하나 생성해야되니
            return;
        }

        stateAtkCtrl.stateAtkControllerStartHandler += delegateAtkStateStart; //stateAtkCtrl만 달면, 시작과 끝에 알림을 할 수 있구만
        stateAtkCtrl.stateAtkControllerEndHandler += delegateAtkStateEnd;

        Debug.Log(iAtkAble.nowAtkBehaviour.aniMotionIdx + ": " + iAtkAble.nowAtkBehaviour.atkRange);

        animator?.SetInteger(atkIndexHash, iAtkAble.nowAtkBehaviour.aniMotionIdx);

        animator?.SetTrigger(atkTriggerHash);



       
    }

    public void delegateAtkStateStart()
    {
        stateMachine.ChangeState<stateAirPlaneExit>();

        UnityEngine.Debug.Log("delegateAtkStateStart()");
    }

    public void delegateAtkStateEnd()
    {
       

        //끝나면은 이제 탈출하는 State
        UnityEngine.Debug.Log("delegateAtkStateEnd()");
       

    }

    public override void OnUpdate(float deltaTime) { }
}
