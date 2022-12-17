using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPakageFollow : MonoBehaviour
{
    public GameObject Player;

    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("CamRoot");
        transform.position = Player.transform.position;
    }
}
