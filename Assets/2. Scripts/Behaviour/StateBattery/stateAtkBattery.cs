using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateAtkBattery : State<MonsterFSM> //이것도 몬스터가 아니라 종류별로 해야겠구만
{

    private Animator animator;
    private stateAtkController stateAtkCtrl;
    private IAtkAble iAtkAble;

    protected int atkTriggerHash = Animator.StringToHash("Atk");
    protected int atkIndexHash = Animator.StringToHash("AtkIdx");

    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        stateAtkCtrl = stateMachineClass.GetComponent<stateAtkController>();
        iAtkAble = stateMachineClass.GetComponent<IAtkAble>();

    }

    public override void OnStart()
    {
       // Debug.Log("IatkAbalbe" + )
       //쿨타임이라 그런거 아님? 
        if (iAtkAble == null || iAtkAble.nowAtkBehaviour == null) //이거 아이들되서 그ㅓㄹㄴ거 아니야? 애니메이터 애니메이션 문제거나, null때문에 idle 되거나
        {
            stateMachine.ChangeState<stateIdleBattery>(); //그러고보니까 이것도 하나 생성해야되니
            
            Debug.Log("헤헿");
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
        UnityEngine.Debug.Log("delegateAtkStateStart()");
    }

    public void delegateAtkStateEnd()
    {
        UnityEngine.Debug.Log("delegateAtkStateEnd()");
        stateMachine.ChangeState<stateIdleBattery>();
    }

    public override void OnUpdate(float deltaTime) { }
}
