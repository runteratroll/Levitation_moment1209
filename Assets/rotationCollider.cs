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
        //이러는 이유가 아마도 180도가 넘어가면 마이너스가 되서 그런거 같에


        //look = Quaternion.LookRotation(nextPos.transform.position);
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
