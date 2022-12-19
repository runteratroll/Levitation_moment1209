using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAroundfor : MonoBehaviour
{
    private int damage = 0;

    private bool isBulletHit;

    private void Awake()
    {
        isBulletHit = false;
    }
    public void DamageBulletHit(int _damage, bool _isBulletHit)
    {
        damage = _damage;
        isBulletHit = _isBulletHit;

    }



    public void OnTriggerStay(Collider other)
    {

        if(isBulletHit)
        {
            if(other.CompareTag("Player") || other.CompareTag("Base"))
            {
                

           
                IDmgAble iDmgAble = other.gameObject.GetComponent<IDmgAble>();

                if (iDmgAble != null)
                {
                    //Debug.Log("히히 데미지");

                    Debug.Log("플레이어 어라운드 데미진");
                    iDmgAble.setDmg(damage, null); //atk 데미지 할 필요없지?
                    DamagePopup.Create(other.transform.position, damage, false, true);

                    Destroy(gameObject);
                    //그러네 플레이어는 MonsterFsm에 attackBehaviour가 없었잖아 그러니 그렇지 0이니까 안바뀐거였어
                }



                
            }

        }
        //콜라이더 불렛에 맞을때 true되가지고 그때 Player감지

    }
}
