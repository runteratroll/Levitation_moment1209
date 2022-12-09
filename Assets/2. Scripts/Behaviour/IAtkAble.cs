using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
 
public interface IAtkAble
{ 
    AtkBehaviour nowAtkBehaviour //이거 왜 해주는 거지
    {
        get;
    }
     
    void OnExecuteAttack(int atkIdx); //이거 왜해는지, 
}
 
