using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;

public class PlayerSerachCamera : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;

    void Update()
    {
        
        SerachPlayer();
        
    }

    void SerachPlayer()
    {
        VirtualCamera.Follow = GameObject.FindGameObjectWithTag("root").transform;
        VirtualCamera.LookAt = GameObject.FindGameObjectWithTag("root").transform;
    }
}