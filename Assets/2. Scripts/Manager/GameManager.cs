using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;


    public GameObject player;

    //public float gameManagerTime = 1f;
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

    //static public float GameManagerTime
    //{
    //    get
    //    {
    //        return instance.gameManagerTime;
    //    }
    //    set
    //    {
    //        float v = Mathf.Clamp(value, 0f, 1f);

    //        instance.gameManagerTime = v;
    //    }
    //}

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
