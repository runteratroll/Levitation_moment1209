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

       // GameManager.GameManagerTime = 1f;
    }

    private void Update()
    {
        //dieCount++;
        dieC = dieCount;


    }
    public override void setDmg(int dmg, GameObject prefabEffect)
    {
        if (!getFlagLive)
        {
            //������ ó�� ���� 
            return;
        }

        //�� �׾��ٸ�, ���� hp���� �������� ���� ���ش� 
        currentHealth -= dmg;
        hpBar.hp -= (float)dmg; //���� �����ϰ� �ִ� HpBar�� Hp�� ���δ�. 
        //healthSystem.Damage(dmg);



        //if (atkEffectPrefab)
        //{
        //    Instantiate(atkEffectPrefab, weaponHitTransform); //������ �ً�, ����Ʈ����Ʈ�� �ֳ�
        //    //weaponHitTransform��  ������ Ŭ���� ���� �ʿ� �߰��ϰ� ���ƿ´�
        //    //Į�� �¾Ҵ� �� �� Į�� ��ġ
        //    //���� ���� 
        //}

        //������ ���� �ϰ� 0 ���ϰ� �Ǹ� ���� ���°� �ǰ���
        //�ٵ� ������ �����ص� ��� �ִ� ���¸� 
        if (getFlagLive)
        {

        }
        else
        {
            //���� ���¸� stateDie�� ���� ��ȯ 
            //fsmManager.ChangeState<stateDie>(); //
            Invoke("Die", 0.5f);
        }
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
                //DieDamage.instance.RetryPopup();

                SceneManager.LoadScene("DieScene");
                dieCount = 0;
                //GameManager.GameManagerTime = 0f;

            }
        }

    }


}
