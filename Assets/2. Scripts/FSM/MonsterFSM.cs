using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFSM : MonoBehaviour
{

    protected StateMachine<MonsterFSM> fsmManager; //fsmManager�� Statemachine<MonsterFSM>�� ����
    public StateMachine<MonsterFSM> FsmManager => fsmManager;

    protected UnityEngine.AI.NavMeshAgent agent;
    protected Animator animator;


    public FieldofCollider foc;

    public Transform target => foc?.target;




    protected virtual void Start()
    {
   


    }

    protected virtual void Update()
    {
        fsmManager.Update(Time.deltaTime);
    }

    public virtual Transform SearchMonster()
    {
        return target; //Ÿ�� 
    }



    public float atkRange;

    public virtual bool getFlagAtk
    {
        get
        {
            Debug.Log("getFlagAtk");
            if (!target)
            {
                return false;
            }

            float distance = Vector3.Distance(transform.position, target.position);
            Debug.Log("=======atkRange" + atkRange);
            return (distance <= atkRange);
        }
    }

    
}





