using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerChange : MonoBehaviour
{
    public GameObject[] player;
    public PlayerSelectFrame playerSelectFrame;
    public int ch = 0;

    public PlayerHealth[] playerHealths;
    void Start()
    {
        player[1].SetActive(false);
        player[2].SetActive(false);
        player[0].SetActive(true);
        //playerHealths[0] = player[0].GetComponent<PlayerHealth>(); 
        //playerHealths[1] = player[1].transform.GetChild(1).GetComponent<PlayerHealth>();
        //playerHealths[2] = player[2].transform.GetChild(1).GetComponent<PlayerHealth>();

        playerSelectFrame.Select(ch);
    }

    void Update()
    {
        Change();
    }
    
    void Change()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && ch != 0 && playerHealths[0].dead == false)
        {

            
            player[1].SetActive(false);
            player[2].SetActive(false);
            player[0].SetActive(true);

            
            ch = 0;
            playerSelectFrame.Select(ch);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && ch != 1 && playerHealths[1].dead == false)
        {
            
            player[0].SetActive(false);
            player[2].SetActive(false);
            player[1].SetActive(true);
            ch = 1;
            playerSelectFrame.Select(ch);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && ch != 2 && playerHealths[2].dead == false)
        {
            
            player[0].SetActive(false);
            player[1].SetActive(false);
            player[2].SetActive(true);
            ch = 2;
            playerSelectFrame.Select(ch);
        }
        
    }
}
