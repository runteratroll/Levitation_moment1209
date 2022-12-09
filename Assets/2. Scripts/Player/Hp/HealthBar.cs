using UnityEngine;


public class HealthBar : MonoBehaviour
{

    private HealthSystem healthSystem;

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
    private void UpdateHealthBar()
    {
        //Debug.Log("업데잍트헬스바");

        //모든 자식들이 될떄까지 기다리기
        transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);


    }




}

