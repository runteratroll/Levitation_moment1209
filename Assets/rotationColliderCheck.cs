using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationColliderCheck : MonoBehaviour
{


    private ShipEnemy shipEnemy;
    //�ڽ��� ã�ư����� 
    private Vector3 rotation = Vector3.zero;



    private void Awake()
    {
        shipEnemy = GetComponentInParent<ShipEnemy>();
    }
    public void Setup(Vector3 _rotValue)
    {
        //rotation = Vector3.zero;
        rotation = _rotValue;

    }


    //ȸ�������ֱ�



    public Quaternion rotShipEnemy()
    {

        if(rotation == Vector3.zero)
        {
            return shipEnemy.transform.rotation;
        }
        else 
        {
            Debug.Log("rotation�� ����? " + rotation);
            //üũ�� �ؾ��ϴµ� ������ �ع��ȳ� �̷��� �ȵǴµ�
            rotation.z = 0f;
            rotation.x = 0f;
            Quaternion nextDirect = Quaternion.Euler(rotation);


            Quaternion lerpRot = Quaternion.Lerp(shipEnemy.transform.rotation, nextDirect, 0.2f * Time.deltaTime);
            //Vector3 shipRot = Quaternion.Euler(shipEnemy.transform.rotation);


            lerpRot.z = 0;
            lerpRot.x = 0;
            if (rotation != Vector3.zero)
            {
               // Debug.Log("���� ȸ���� " + lerpRot);
            }


            return lerpRot; //�����̼ǰ��� ���ٸ� �ڱ� ȸ������ ����ϰ�, �ִٸ� ������  �����̼ǰ��� ��
        }

       
    }

}