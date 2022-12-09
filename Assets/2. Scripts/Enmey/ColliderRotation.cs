using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRotation : MonoBehaviour
{

    public GameObject gunPos;

    public float rot;
    public float re;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rot = gunPos.transform.eulerAngles.y;


        re = rot - 180;
            //-200 = 20
            //-160 = -20
        transform.rotation = Quaternion.Euler(-90, 0, re);
    }
}
