using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationCollider : MonoBehaviour
{

    public Vector3 rotValue;
    //private bool istouch = false;

    private void Awake()
    {

        //Vector3 dir = rotValue - Arrow.transform.position;
        //이러는 이유가 아마도 180도가 넘어가면 마이너스가 되서 그런거 같에


       //Quaternion look = Quaternion.LookRotation(dir );
        //look = 

       
      

    }
    private void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {

        //if(other.CompareTag("rotationCheck"))
        //{
        //    Debug.Log("어떻게 되는거야?");
        //}
        //Debug.Log("어떻게 되는거야?");
        if (other.gameObject.layer == LayerMask.NameToLayer("rotationColliderCheck"))
        {
            //istouch = true;
            Debug.Log("어떻게 되는거야?");
            rotationColliderCheck rotationCheck = other.GetComponent<rotationColliderCheck>();

            rotationCheck.Setup(rotValue);
        }
    
    }
}
