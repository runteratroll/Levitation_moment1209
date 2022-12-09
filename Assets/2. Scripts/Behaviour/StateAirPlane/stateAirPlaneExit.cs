using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class stateAirPlaneExit : State<MonsterFSM>
{

    public override void OnStart()
    {
        stateMachineClass.transform.DOLocalMove(stateMachineClass.transform.position + stateMachineClass.transform.up * 10f + stateMachineClass.transform.forward * 20f , 1f).OnComplete(() =>
        {
            stateMachine.ChangeState<stateAirPlaneDie>();
        });
            
    }

    public override void OnUpdate(float deltaTime)
    {

    }
}
