using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MeleeTypeAtkBehaviour : AtkBehaviour
{ 
    public CollisionMeleeAtk collisionMeleeAtk;
     
    public override void callAtkMotion(GameObject target = null, Transform posAtkStart = null)
    {
        Collider[] colliders = collisionMeleeAtk?.CheckOverlapBox(targetLayerMask);
         
        foreach (Collider col in colliders)
        { 
            col.gameObject.GetComponent<IDmgAble>()?.setDmg(atkDmg, atkEffectPrefab);
        }


        nowAtkCoolTime = 0.0f;
    }
    //인터페이스로 만들어야겠다.

} 