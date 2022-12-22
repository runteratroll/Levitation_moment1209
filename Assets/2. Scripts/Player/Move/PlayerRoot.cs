 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
    public float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�
    public float moveSpeed = 4.0f; // �̵� �ӵ�

    private float yRotateSize;
    public float yRotate;
    private float xRotateSize;
    public float xRotate;

    public GameObject camPos;
    public GameObject gunPos;

    public float heigt = 1.5f;
    public Vector3 move;


  
    void Update()
    {
        camPos = FindObjectOfType<PlayerHealth>().gameObject;
        gunPos = FindObjectOfType<GunPosIn>().gameObject;

        yRotateSize = Input.GetAxis("Mouse X") * turnSpeed ;
        yRotate = transform.eulerAngles.y + yRotateSize;
        xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed ;
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -70, 70);

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        camPos.transform.eulerAngles = new Vector3(0, yRotate, 0);
        gunPos.transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        move =
            camPos.transform.forward * Input.GetAxis("Vertical")  +
            camPos.transform.right * Input.GetAxis("Horizontal") ;


        transform.position += move * moveSpeed * Time.deltaTime;

        camPos.transform.position = new Vector3(transform.position.x, transform.position.y + heigt, transform.position.z);
    }
}
