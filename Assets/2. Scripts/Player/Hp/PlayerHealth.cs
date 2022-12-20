using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : LivingEntity
{

    static int dieCount;

    public int dieC;
    private void Awake()
    {
        dead = false;
        dieCount = 0;
    }
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        //dieCount++;
        dieC = dieCount;


    }
    public override void setDmg(int dmg, GameObject prefabEffect)
    {
        base.setDmg(dmg, prefabEffect);
    }

    public override void Die()
    {
        if (getFlagLive == false && dead == false)  //�׾���, dead�� ���� Ʈ�簡 �ƴ϶��(���� �긦 üũ�ؼ� �� deathCoount�� �ø��� �ȵǱ⿡
        {


            Debug.Log("DiedIDIDIe");
            dieCount++;
            dead = true;


            if (dieCount >= 3)
            {
                //�� �����
                DieDamage.instance.RetryPopup();
                dieCount = 0;
                

            }
        }

    }


}
