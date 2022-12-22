using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationCollider : MonoBehaviour
{

    //public Vector3 rotValue;
    //private bool istouch = false;

    public Transform nextPos;
    public bool isBase = false;
    public bool isStop = false;
    public int baseRotation;
    Vector3 lookDir;

    private void Awake()
    {

        if(isBase)
        {
            nextPos = FindObjectOfType<militarybaseHealth>().transform;
        }

        //Vector3 dir = rotValue - Arrow.transform.position;
        //�̷��� ������ �Ƹ��� 180���� �Ѿ�� ���̳ʽ��� �Ǽ� �׷��� ����


        //look = Quaternion.LookRotation(nextPos.transform.position);
        //look = 

 
     

    }
    private void OnTriggerEnter(Collider other)
    {

        //if(other.CompareTag("rotationCheck"))
        //{
        //    Debug.Log("��� �Ǵ°ž�?");
        //}
        //Debug.Log("��� �Ǵ°ž�?");
        if (other.gameObject.layer == LayerMask.NameToLayer("rotationColliderCheck"))
        {
            //istouch = true;


            if (nextPos != null)
            {
                lookDir = (nextPos.position - other.gameObject.transform.position).normalized;

                lookDir.y = 0f;
            }

            rotationColliderCheck rotationCheck = other.GetComponent<rotationColliderCheck>();

            rotationCheck.Setup(lookDir, baseRotation, isStop);
        }
    
    }
}
