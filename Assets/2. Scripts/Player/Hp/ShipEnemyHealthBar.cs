using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemyHealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;

    public ShipEnemy shipEnemy;

    private void Start()
    {
        InvokeRepeating("UpdateHealthBar", 0, 0.01f); //0���� 0.1�ʸ��� ����
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
