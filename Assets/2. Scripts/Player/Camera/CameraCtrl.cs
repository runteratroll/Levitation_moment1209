using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;

public class CameraCtrl : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;
    public bool qeBool = true;

    void Update()
    {

        
        Zoom();
        QETab();
    }

    void Zoom()
    {
        if (Input.GetMouseButton(1)) VirtualCamera.m_Lens.FieldOfView = math.lerp(VirtualCamera.m_Lens.FieldOfView, 30, 0.15f);
        else VirtualCamera.m_Lens.FieldOfView = math.lerp(VirtualCamera.m_Lens.FieldOfView, 60, 0.15f);
    }

    void QETab()
    {
        

        if (qeBool)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                qeBool = false;
            }
            VirtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraSide =
            math.lerp(VirtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraSide, 1, 0.15f);
        }
        else if (!qeBool)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                qeBool = true;
            }
            VirtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraSide =
            math.lerp(VirtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraSide, 0, 0.15f);
        }
    }
}
