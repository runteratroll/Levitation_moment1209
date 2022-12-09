using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[Serializable]
public class stateAirPlaneDie : State<MonsterFSM>
{
    private Animator animator;

    protected int flagLive = Animator.StringToHash("flagLive");
    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
    }

    public override void OnStart()
    {
        animator?.SetBool(flagLive, false);



    }

    public override void OnUpdate(float deltaTime)
    {
        if (stateMachine.getStateDurationTime > 0.5f)
        {
            Debug.Log("�ױ�");
            GameObject.Destroy(stateMachineClass.gameObject);
        }
    }

    public override void OnEnd() { }
}
