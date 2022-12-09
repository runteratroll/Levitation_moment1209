using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTypeStateMachineBehaviour : StateMachineBehaviour
{
    //Idle id Type Count
    public int idleIDCnt = 2;

    //Base Idle Action Random Time
    public float minBaseIdleTime = 0f;
    public float maxBaseIdleTime = 5f;
    protected float rndBaseIDleTime;


    //Base Idle State Start 
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Random Time
        rndBaseIDleTime = Random.Range(minBaseIdleTime, maxBaseIdleTime);
    }

    //Base Idle State Update
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //IdleStateMAchine가 아닌 BaseLayer인가 ?
        if(animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).fullPathHash == stateInfo.fullPathHash)
        {
            animator.SetInteger("Idle_id", -1);
        }

        //IdleStateMAchine이면서 IdleStateMAchine Active Time 이후인가 
        if (stateInfo.normalizedTime > rndBaseIDleTime && !animator.IsInTransition(0))
        {
            //IdleStateMAchine의 ID를 Random으로 선택 
            animator.SetInteger("Idle_id", Random.Range(0, idleIDCnt));
        }
    } 
}
