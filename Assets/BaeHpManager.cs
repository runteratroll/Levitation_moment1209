using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaeHpManager : MonoBehaviour
{

    public militarybaseHealth[] militaryBase;


    public HpBar hpbar;
    public float totalMaxHp = 0f;
    public float currentTotalMaxHp;
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < militaryBase.Length; i++)
        {
            totalMaxHp += militaryBase[i].maxHealth;

        }
        currentTotalMaxHp = totalMaxHp;

        hpbar.maxHp = totalMaxHp;
        hpbar.hp = totalMaxHp;
    }

    public void DmgHealth()
    {
        Debug.Log("´Ù´Ï?");
        currentTotalMaxHp = 0;
        for (int i = 0; i < militaryBase.Length; i++)
        {
            if (militaryBase[i].currentHealth <= 0)
            {
                militaryBase[i].currentHealth = 0;
            }

            currentTotalMaxHp += militaryBase[i].currentHealth;

        }

        hpbar.hp = currentTotalMaxHp;
    }


}
