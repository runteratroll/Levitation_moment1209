using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemyHealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;

    public ShipEnemy shipEnemy;

    private Transform tran;
    private Transform tranChild;
    private Transform background;
    private void Start()
    {
        InvokeRepeating("UpdateHealthBar", 0, 0.01f); //0���� 0.1�ʸ��� ����
        tran = transform.Find("Bar").transform;
        tranChild = tran.Find("sprite").transform;
        background = transform.Find("Background").transform;
        float v = (tranChild.localScale.x / 2) / 100;

        background.localScale = tranChild.localScale;
        //1300이면 그 반에 / 
        tran.transform.localPosition = new Vector3(v, 0, 0);
        tranChild.transform.localPosition = new Vector3(-v, 0, 0);
    }
    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;

        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        UpdateHealthBar();
    }

    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        UpdateHealthBar();
    }

    //�ڱ� �ｺ�ý��ۿ���, �ǰ� ���϶� �̺�Ʈ�� ��ȯ�ϴϱ� 

    //��Ͻ����� 
    
    public void UpdateHealthBar()
    {

        //�ȵǴ�������, OnHealth 

        //�ٵ��̰� �ǰ� �޾Ƶ� �ٷδ� ����ȵǳ�? ����? ]
        //�����Ͱ� �������� �ؼ� �׷���

        //yield return null;
     
        transform.Find("Bar").localScale = new Vector3(shipEnemy.GetBatteryCurrentHp(), 1); //�ڽ� Hp�� �ȱ������µ�


    }
}
