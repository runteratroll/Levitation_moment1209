using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MAtkTypeStateMachineBehaviour : StateMachineBehaviour
{ 
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        animator.gameObject.GetComponent<stateAtkController>()?.EventStateAtkStart(); //�̰� ���� ������ ����
    }
  //�ִ̾ϸ��̼ǿ� �����ϸ� ���� �׼��ҷ��� �̷��� ���������
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        animator.gameObject.GetComponent<stateAtkController>().EventStateAtkEnd(); //�̰� ���� ��������
        //
    } 
}
