using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoMove : BulletMove
{
    protected override void Update()
    {
        float y = Mathf.Clamp(transform.position.y, -0.2819754f, 10f);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        
        base.Update();
    }
}
