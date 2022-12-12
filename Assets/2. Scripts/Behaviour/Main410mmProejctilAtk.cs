using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main410mmProejctilAtk : CollisionProjectileAtk
{

    public GameObject damageAround;

    private GameObject damageObj;

    protected override void Start()
    {
        base.Start();
        damageObj = Instantiate(damageAround, transform.position, Quaternion.identity);

        damageObj.transform.position = target.transform.position + new Vector3(0, -0.4f, 0); //소환되고

    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if(other.CompareTag("410mainProjectile"))
        {

        }
    }

}
