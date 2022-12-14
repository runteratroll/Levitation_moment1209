using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHPManager : MonoSingleton<PlayerHPManager>
{


    //public List<PlayerHealth> playerHealths;


    public int deathCount = 0;


    private void Start()
    {
        deathCount = 0;
    }

    //3명이 죽을떄 체크, 3명의 이벤트가 죽는다면?

    public void PlayerHelathCheck(PlayerHealth playerHealth)
    {
        if (playerHealth.getFlagLive == false && playerHealth.dead == false)  //죽었고, dead가 아직 트루가 아니라면(같은 얘를 체크해서 또 deathCoount를 늘리면 안되기에
        {
            Debug.Log("죽기");
            deathCount++;
            playerHealth.dead = true;


            if (deathCount >= 3)
            {
                //씬 재시작

                deathCount = 0;
                SceneManager.LoadScene("SeungHoon2");

            }
        }
    }




}
