using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationCollider : MonoBehaviour
{

    public Vector3 rotValue;
    //private bool istouch = false;

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
            Debug.Log("��� �Ǵ°ž�?");
            rotationColliderCheck rotationCheck = other.GetComponent<rotationColliderCheck>();

            rotationCheck.Setup(rotValue);
        }
    
    }
}