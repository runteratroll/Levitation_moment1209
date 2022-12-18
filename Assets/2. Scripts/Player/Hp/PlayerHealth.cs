using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : LivingEntity
{

    static int dieCount;

    private void Awake()
    {
        dead = false;
        dieCount = 0;
    }
    protected override void Start()
    {
        base.Start();
    }

    public override void setDmg(int dmg, GameObject prefabEffect)
    {
        base.setDmg(dmg, prefabEffect);
    }

    public override void Die()
    {
        if (getFlagLive == false && dead == false)  //�׾���, dead�� ���� Ʈ�簡 �ƴ϶��(���� �긦 üũ�ؼ� �� deathCoount�� �ø��� �ȵǱ⿡
        {
            dieCount++;
            dead = true;


            if (dieCount >= 3)
            {
                //�� �����

                dieCount = 0;
                SceneManager.LoadScene("SeungHoon2");

            }
        }
       
    }


}
