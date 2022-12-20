using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    void Update()
    {

        Cursor.visible = false;                     //���콺 Ŀ���� ������ �ʰ� ��
        Cursor.lockState = CursorLockMode.Locked;   //���콺 Ŀ���� ������Ŵ
    }
}
