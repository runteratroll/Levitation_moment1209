using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;


    public GameObject player;

    static public GameObject Player
    {
        get
        {
            return instance.player;
        }


        set
        {

        }

    }

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);

        }
        
    }
}
