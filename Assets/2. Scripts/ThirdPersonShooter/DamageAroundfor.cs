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
    private GameObject bullet;
    public void DamageBulletHit(int _damage, bool _isBulletHit , GameObject _gameObject = null)
    {
        damage = _damage;
        isBulletHit = _isBulletHit;
        bullet = _gameObject;

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
                    //Debug.Log("���� ������");

                    Debug.Log("코드문제");
                    iDmgAble.setDmg(damage, null); //atk ������ �� �ʿ����?
                    DamagePopup.Create(other.transform.position, damage, false, true);

                  
                    //�׷��� �÷��̾�� MonsterFsm�� attackBehaviour�� �����ݾ� �׷��� �׷��� 0�̴ϱ� �ȹٲ�ſ���
                }



                
            }

            Destroy(bullet);
            Destroy(gameObject);

        }

        //�ݶ��̴� �ҷ��� ������ true�ǰ����� �׶� Player����

    }
}
