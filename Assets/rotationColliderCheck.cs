using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationColliderCheck : MonoBehaviour
{



    //자식을 찾아가지고 
    private Vector3 rotation = Vector3.zero;
   


    private void Awake()
    {
      
    }
    public void Setup(Vector3 _rotValue)
    {
        //rotation = Vector3.zero;
        rotation = _rotValue; //50

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
            Debug.Log("rotation의 값은? " + rotation);
            //체크만 해야하는데 로직도 해버렸네 이러면 안되는데
            rotation.z = 0f;
            rotation.x = 0f;
            Quaternion nextDirect = Quaternion.Euler(rotation);


            Quaternion lerpRot = Quaternion.Lerp(transform.rotation, nextDirect, 0.7f * Time.deltaTime );
            //Vector3 shipRot = Quaternion.Euler(shipEnemy.transform.rotation);


            lerpRot.z = 0;
            lerpRot.x = 0;
            if (rotation != Vector3.zero)
            {
               // Debug.Log("보간 회전값 " + lerpRot);
            }


            return lerpRot; //로테이션값이 없다면 자기 회전값을 사용하고, 있다면 설정한  로테이션값을 줌
        }

       
    }

}
