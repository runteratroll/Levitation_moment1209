using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MAtkTypeStateMachineBehaviour : StateMachineBehaviour
{ 
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        animator.gameObject.GetComponent<stateAtkController>()?.EventStateAtkStart(); //이걸 만든 이유가 뭐지
    }
  //이애니메이션에 진입하면 무언가 액션할려고 이렇게 만들었구나
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        animator.gameObject.GetComponent<stateAtkController>().EventStateAtkEnd(); //이걸 만든 이유가음
        //
    } 
}
