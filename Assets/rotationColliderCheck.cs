using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationColliderCheck : MonoBehaviour
{



    //�ڽ��� ã�ư����� 
    private Vector3 rotation = Vector3.zero;


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
            return transform.rotation;
        }
        else 
        {
            Quaternion from = transform.rotation;
            Quaternion to = Quaternion.LookRotation(rotation);

            
          

            return Quaternion.Lerp(from, to, Time.deltaTime * 5f); //�����̼ǰ��� ���ٸ� �ڱ� ȸ������ ����ϰ�, �ִٸ� ������  �����̼ǰ��� ��
        }

       
    }

}
