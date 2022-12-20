using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationCollider : MonoBehaviour
{

    public Vector3 rotValue;
    //private bool istouch = false;

    GameObject Arrow;
    private void Awake()
    {
        Arrow = Instantiate(GameAssets.i.ColliderRotationArrow, transform.position, Quaternion.identity);

        Vector3 dir = rotValue - Arrow.transform.position;



       Quaternion look = Quaternion.LookRotation(dir );
        //look = 

       
      

    }
    private void Update()
    {
        Arrow.transform.rotation = Quaternion.Euler(90f, rotValue.y, rotValue.z);
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
            Debug.Log("��� �Ǵ°ž�?");
            rotationColliderCheck rotationCheck = other.GetComponent<rotationColliderCheck>();

            rotationCheck.Setup(rotValue);
        }
    
    }
}
