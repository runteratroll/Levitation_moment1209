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
        if (getFlagLive == false && dead == false)  //죽었고, dead가 아직 트루가 아니라면(같은 얘를 체크해서 또 deathCoount를 늘리면 안되기에
        {


            Debug.Log("DiedIDIDIe");
            dieCount++;
            dead = true;


            if (dieCount >= 3)
            {
                //씬 재시작
                DieDamage.instance.RetryPopup();
                dieCount = 0;
                

            }
        }

    }


}
