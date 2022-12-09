using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemyHealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;

    public ShipEnemy shipEnemy;

    private void Start()
    {
        InvokeRepeating("UpdateHealthBar", 0, 0.01f); //0초후 0.1초마다 실행
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

    //자기 헬스시스템에서, 피가 깍일때 이벤트를 소환하니까 

    //등록시켜줌 
    
    public void UpdateHealthBar()
    {

        //안되는이유가, OnHealth 

        //근데이거 피가 달아도 바로는 실행안되네? 왜지? ]
        //데이터가 들어가기전에 해서 그런가

        //yield return null;
        Debug.Log("ShipEnmeyHealthBa");
     
        transform.Find("Bar").localScale = new Vector3(shipEnemy.GetBatteryCurrentHp(), 1); //자식 Hp가 안구해졌는데


    }
}
