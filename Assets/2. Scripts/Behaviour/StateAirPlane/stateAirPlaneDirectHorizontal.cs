using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateAirPlaneDirectHorizontal : State<MonsterFSM>
{
    Rigidbody rigid;


    public override void OnAwake()
    {
        rigid = stateMachineClass.GetComponent<Rigidbody>();
    }

    public override void OnStart()
    {

    }

    public override void OnUpdate(float deltaTime)
    {

        

        
        
    }


    public override void OnEnd()
    {
    }



}
