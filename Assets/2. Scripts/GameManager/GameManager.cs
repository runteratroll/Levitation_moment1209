using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform player;

    public static Transform Player
    {
        get
        {
            return instance.player;
        }
    }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        //player = FindObjectOfType<PlayerHealth>().transform;
    }
}
