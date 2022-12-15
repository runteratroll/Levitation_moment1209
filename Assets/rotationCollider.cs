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
