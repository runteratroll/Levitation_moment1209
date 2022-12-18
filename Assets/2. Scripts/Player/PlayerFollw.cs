using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollw : MonoBehaviour
{
    public GameObject player;



    private void Update()
    {

        player = FindObjectOfType<PlayerHealth>().gameObject;
        transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
    }
}
