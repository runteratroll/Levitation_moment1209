using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : CollisionProjectileAtk
{

    //[SerializeField] private Transform vfxHitGreen;
    //[SerializeField] private Transform vfxHitRed;

    public LayerMask WhoisEnemy;

    protected override void OnTriggerEnter(Collider other)
    {
        
            base.OnTriggerEnter(other);
        
       
    }
    protected override void OnProjectileStartCollision(Collider other)
    {
        base.OnProjectileStartCollision(other);
    }


}