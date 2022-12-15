using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BaseManager : MonoSingleton<BaseManager>
{

    //public List<militayhealth> militayhealths;


    public int deathCount = 0;


    private void Start()
    {
        deathCount = 0;
    }

    //3���� ������ üũ, 3���� �̺�Ʈ�� �״´ٸ�?

    public void MilitaryBaseCheck(militarybaseHealth militayhealth)
    {
        if (militayhealth.getFlagLive == false && militayhealth.dead == false)  //�׾���, dead�� ���� Ʈ�簡 �ƴ϶��(���� �긦 üũ�ؼ� �� deathCoount�� �ø��� �ȵǱ⿡
        {
            Debug.Log("�ױ�");
            deathCount++;
            militayhealth.dead = true;


            if (deathCount >= 2)
            {
                //�� �����

                deathCount = 0;
                SceneManager.LoadScene("SeungHoon2");

            }
        }
    }

}
