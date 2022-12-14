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

    //3���� ������ üũ, 3���� �̺�Ʈ�� �״´ٸ�?

    public void PlayerHelathCheck(PlayerHealth playerHealth)
    {
        if (playerHealth.getFlagLive == false && playerHealth.dead == false)  //�׾���, dead�� ���� Ʈ�簡 �ƴ϶��(���� �긦 üũ�ؼ� �� deathCoount�� �ø��� �ȵǱ⿡
        {
            Debug.Log("�ױ�");
            deathCount++;
            playerHealth.dead = true;


            if (deathCount >= 3)
            {
                //�� �����

                deathCount = 0;
                SceneManager.LoadScene("SeungHoon2");

            }
        }
    }




}
