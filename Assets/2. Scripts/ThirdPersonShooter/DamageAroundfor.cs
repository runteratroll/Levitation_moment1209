using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAroundfor : MonoBehaviour
{
    private int damage = 0;

    private bool isBulletHit;

    public void DamageBulletHit(int _damage, bool _isBulletHit)
    {
        damage = _damage;
        isBulletHit = _isBulletHit;

    }

   
    public void OnTriggerStay(Collider other)
    {

        if(isBulletHit)
        {
            if(other.CompareTag("Player"))
            {

                IDmgAble iDmgAble = other.gameObject.GetComponent<IDmgAble>();

                if (iDmgAble != null)
                {
                    //Debug.Log("���� ������");

                    Debug.Log("�÷��̾� ����� ������");
                    iDmgAble.setDmg(damage, null); //atk ������ �� �ʿ����?
                    DamagePopup.Create(other.transform.position, damage, false, true);
                    //�׷��� �÷��̾�� MonsterFsm�� attackBehaviour�� �����ݾ� �׷��� �׷��� 0�̴ϱ� �ȹٲ�ſ���
                }



                
            }

            Destroy(gameObject);
        }
        //�ݶ��̴� �ҷ��� ������ true�ǰ����� �׶� Player����

    }
}