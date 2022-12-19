using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main410mmProejctilAtk : CollisionProjectileAtk
{

    public GameObject damageAround;

    private GameObject damageObj;

    private int range;
    private int idx;

    protected override void Start()
    {
        base.Start();


        InstanceDamageAround();

    }


    public void InstanceDamageAround()
    {
        Debug.Log("소환되니?");
        damageObj = Instantiate(damageAround);

        damageObj.transform.position = target.transform.position + Vector3.up * 0.2f; //��ȯ�ǰ�
        damageObj.transform.localScale = new Vector3(damageObj.transform.localScale.x, 0.01f, damageObj.transform.localScale.z);

        //랜덤 레인지 
        range = Random.Range(0, 3000000);

        idx = range;



    }



    protected override void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("DamageAround") && idx == range)
        {
            
            //가끔가다 //여기오류나는 이유가 다른 DamageAround를 만나가지고 없어져서 그렇네

            if(damageObj != null)
            {

                DamageAroundfor damageAroundfor = damageObj?.GetComponent<DamageAroundfor>();
                damageAroundfor.DamageBulletHit(damage, true);
            }






        }
    }

}
