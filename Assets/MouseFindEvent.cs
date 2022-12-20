using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFindEvent : MonoBehaviour
{
    void Update()
    {

        Cursor.visible = true;                     //���콺 Ŀ���� ������ �ʰ� ��
        Cursor.lockState = CursorLockMode.Confined;   //���콺 Ŀ���� ������Ŵ
    }
}
