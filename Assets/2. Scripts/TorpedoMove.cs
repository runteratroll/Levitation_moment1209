using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoMove : BulletMove
{
    protected override void Update()
    {
        float y = Mathf.Clamp(transform.position.y, -0.2819754f, 10f);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        float rx = Mathf.Clamp(transform.eulerAngles.x, 0f, 0f);
        transform.rotation = Quaternion.Euler(rx, transform.eulerAngles.y, transform.eulerAngles.z);
        
        base.Update();
    }
}
