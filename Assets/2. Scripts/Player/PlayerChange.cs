using UnityEngine;
using Cinemachine;


public class PlayerChange : MonoBehaviour
{

    public CinemachineVirtualCamera virtualCamera;
    public GameObject[] player;


    public PlayerSelectFrame playerSelectFrame;
    public int ch = 0;

    public PlayerHealth[] playerHealths;
    [Header("플레이어 포지션")]
    public Transform[] playerPosition;
    //�ڱ���ü �ϴ°� �����߰ڴ�.


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

        if (ch == 0 && playerHealths[0].dead)
        {
            if (playerHealths[1].dead == false)
            {
                ch = 1;
            }
            else if (playerHealths[2].dead == false)
            {

                ch = 2;
            }
        }
        if (ch == 1 && playerHealths[1].dead)
        {
            if (playerHealths[0].dead == false)
            {
                ch = 0;
            }
            else if (playerHealths[2].dead == false)
            {

                ch = 2;
            }
        }
        if (ch == 2 && playerHealths[2].dead)
        {
            if (playerHealths[0].dead == false)
            {
                ch = 0;
            }
            else if (playerHealths[1].dead == false)
            {

                ch = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && ch != 0 && playerHealths[0].dead == false || (ch == 0 && playerHealths[0].dead == false))
        {




            player[1].SetActive(false);
            player[2].SetActive(false);
            player[0].SetActive(true);
            Debug.Log("테스트");


            ch = 0;
            playerSelectFrame.Select(ch);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && ch != 1 && playerHealths[1].dead == false || (ch == 1 && playerHealths[1].dead == false))
        {


            player[0].SetActive(false);
            player[2].SetActive(false);
            player[1].SetActive(true);
            ch = 1;
            playerSelectFrame.Select(ch);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && ch != 2 && playerHealths[2].dead == false || (ch == 2 && playerHealths[2].dead == false))
        {
            player[0].SetActive(false);
            player[1].SetActive(false);
            player[2].SetActive(true);
            ch = 2;
            playerSelectFrame.Select(ch);
        }


    }
}
