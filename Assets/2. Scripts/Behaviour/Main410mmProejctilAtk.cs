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
            
            //가끔가다 //여기오류나는 이유가 다른 DamageAround를 만나가지고 없어져서 그렇네

            DamageAroundfor damageAroundfor = damageObj.GetComponent<DamageAroundfor>();
            damageAroundfor.DamageBulletHit(damage, true);



        }
    }

}
