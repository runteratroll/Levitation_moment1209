using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoDanger : MonoBehaviour
{
    public GameObject red;
    public GameObject ora;
    public Transform player;
    void Start()
    {
        red.SetActive(false);
        ora.SetActive(false);
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("CamRoot").transform;

        float Distance = Vector3.Distance(player.transform.position, transform.position);

        if(Distance < 10)
        {
            red.SetActive(true);
            ora.SetActive(false);
        }
        else if(Distance < 20)
        {
            red.SetActive(false);
            ora.SetActive(true);
        }
        else
        {
            red.SetActive(false);
            ora.SetActive(false);
        }
    }
}
