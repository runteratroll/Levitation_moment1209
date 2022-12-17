using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;


public class MinimapCameraCtrl : MonoBehaviour
{


    public Transform playerPosition;


    private void Awake()
    {
        
    }

    void Update()
    {
        SerachPlayer();

    }

    void SerachPlayer()
    {
        playerPosition = FindObjectOfType<PlayerHealth>().transform;
        transform.position = new Vector3(playerPosition.position.x, transform.position.y, playerPosition.position.z) ;
    }
}
