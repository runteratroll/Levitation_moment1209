using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneCollisionProjectileAtk : CollisionProjectileAtk
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        
        if (projectileSpd != 0 && rigidbody != null)
        {
            rigidbody.position += (transform.forward) * (projectileSpd * Time.deltaTime); //로컬방향으로 가는데 중력값이 있는거지
            //transform.Translate(Vector3.forward * Time.deltaTime * projectileSpd);
        }
    }

 
}
