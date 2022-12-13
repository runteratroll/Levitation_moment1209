using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Cursor.visible = true;                     //���콺 Ŀ���� ������ �ʰ� ��
            Cursor.lockState = CursorLockMode.None;   //���콺 Ŀ���� ������Ŵ
        }
        else
        {
            Cursor.visible = false;                     //���콺 Ŀ���� ������ �ʰ� ��
            Cursor.lockState = CursorLockMode.Locked;   //���콺 Ŀ���� ������Ŵ
        }
    }
}
