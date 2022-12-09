using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CollisionMeleeAtk : MonoBehaviour
{ 
    public Vector3 boxSize = new Vector3(2, 2, 2); 
    public Collider[] CheckOverlapBox(LayerMask layerMask)
    { 
        return Physics.OverlapBox(transform.position, boxSize * 0.5f, transform.rotation, layerMask);
    }
     
    void OnDrawGizmos()
    { 
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.yellow; 
        Gizmos.DrawWireCube(Vector3.zero, boxSize);
    }
}  