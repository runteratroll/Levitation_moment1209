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

        

        damageObj.transform.position = target.transform.position; //소환되고

    }

    protected override void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("DamageAround"))
        {
            
            //데미지 원범위에 있다면 
            //플레이어가 맞을떄도 해야겠네

            //DamageAround자체에서 
            //Damag
            //Damage //트리거에 플레이어가 있으면 
            //setDamage줒기

            DamageAroundfor damageAroundfor = damageObj.GetComponent<DamageAroundfor>();
            damageAroundfor.DamageBulletHit(damage, true);


            //데미지를 줬다면

        }
    }

}
