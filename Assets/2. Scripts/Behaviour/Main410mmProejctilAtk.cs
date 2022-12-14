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

        damageObj.transform.position = target.transform.position + Vector3.up * 0.14f; //��ȯ�ǰ�




    }

    protected override void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("DamageAround"))
        {
            
            

            DamageAroundfor damageAroundfor = damageObj.GetComponent<DamageAroundfor>();
            damageAroundfor.DamageBulletHit(damage, true);



        }
    }

}
