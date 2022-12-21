using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class rotationColliderCheck : MonoBehaviour
{



    //�ڽ��� ã�ư����� 
    private Vector3 rotation = Vector3.zero;


    ShipEnemy shipEnemy;


    private BoxCollider boxCollider;
    private Rigidbody rigid;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        rigid = GetComponent<Rigidbody>();
        shipEnemy = GetComponentInParent<ShipEnemy>();

        gameObject.layer = LayerMask.NameToLayer("rotationColliderCheck");
        rigid.isKinematic = true;
        rigid.useGravity = false;
        boxCollider.isTrigger = true;
        boxCollider.size = new Vector3(50f, 1f, 1f);
    }
    public int value;
    public bool isStop = false;
    public void Setup(Vector3 _rotValue , int val , bool _isStop = false)
    {
        //rotation = Vector3.zero;
        rotation = _rotValue; //50
        value = val;
        isStop = _isStop;
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
            Quaternion from = shipEnemy.transform.rotation;
            Quaternion to = Quaternion.LookRotation(rotation);

            
          

            return Quaternion.Lerp(from, to, Time.deltaTime * 0.5f); //�����̼ǰ��� ���ٸ� �ڱ� ȸ������ ����ϰ�, �ִٸ� ������  �����̼ǰ��� ��
        }

       
    }

}
