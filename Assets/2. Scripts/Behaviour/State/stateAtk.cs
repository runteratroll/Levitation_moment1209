using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
 
public class stateAtk : State<MonsterFSM>
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
        if (iAtkAble == null || iAtkAble.nowAtkBehaviour == null)
        {
            stateMachine.ChangeState<stateIdle>(); //�׷����ϱ� �̰͵� �ϳ� �����ؾߵǴ�
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
        UnityEngine.Debug.Log("delegateAtkStateEnd()"); 
        stateMachine.ChangeState<stateIdle>();
    }
     
    public override void OnUpdate(float deltaTime) { }
}
