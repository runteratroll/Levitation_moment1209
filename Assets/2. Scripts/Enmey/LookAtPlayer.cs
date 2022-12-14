using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    public float startDeg;
    public float degSec = 3f;

    float y;
    float z;


    void Start()
    {
        
        transform.rotation = Quaternion.Euler(0,startDeg,0);
    }

    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("EnemyAggro").transform;
    }

    public void LookPlayer()
    {

        Vector3 dir = player.position - transform.position;

        Quaternion p = Quaternion.LookRotation(dir);

        y = p.eulerAngles.y;
        z = p.eulerAngles.z;


        //Quaternion s = Quaternion.Euler(0, y, z);


        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            Quaternion.Euler(new Vector3(0, y, z)), //��, 
            180 * Time.deltaTime / degSec);
    }
  
}
