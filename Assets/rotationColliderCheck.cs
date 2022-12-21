using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationColliderCheck : MonoBehaviour
{



    //자식을 찾아가지고 
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


    //회전시켜주기



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

            
          

            return Quaternion.Lerp(from, to, Time.deltaTime * 5f); //로테이션값이 없다면 자기 회전값을 사용하고, 있다면 설정한  로테이션값을 줌
        }

       
    }

}
