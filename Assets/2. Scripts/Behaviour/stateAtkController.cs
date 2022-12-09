using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class stateAtkController : MonoBehaviour
{  
    public delegate void OnStartStateAtkController(); //��������Ʈ
    public OnStartStateAtkController stateAtkControllerStartHandler; //�̰� ���Ѱ�

    public delegate void OnEndStateAtkController(); 
    public OnEndStateAtkController stateAtkControllerEndHandler; //�̰͵� ���Ѱ�
     
    public bool getFlagStateAtkController
    {
        get; 
        private set;
    }

    private void Start()
    { 
        stateAtkControllerStartHandler
            = new OnStartStateAtkController(stateAtkControllerStart); 
        stateAtkControllerEndHandler
            = new OnEndStateAtkController(stateAtkControllerEnd);
    }
     
    private void stateAtkControllerStart()
    {
        //Ÿ�̹��̶�� ���⼭ �װ��ϰ���? �����Ҷ��� �÷��̾���� ��� �ð��� ���۵Ǵºκ�
        //������ ���� �ϴ°ǰ�
    }

    private void stateAtkControllerEnd()
    {
        //�ִϸ��̼��� �����餤
    }
     
    public void EventStateAtkStart() //�Լ� �����ҷ��� 
    { 
        getFlagStateAtkController = true; 
        stateAtkControllerStartHandler();
    }
      
    public void EventStateAtkEnd()
    { 
        getFlagStateAtkController = false; 
        stateAtkControllerEndHandler();
    }
     
    public void OnCheckAttackCollider(int attackIndex)
    {
        Debug.Log("---------------------attackIndex : " + attackIndex);
        GetComponent<IAtkAble>()?.OnExecuteAttack(attackIndex);
    }
}
