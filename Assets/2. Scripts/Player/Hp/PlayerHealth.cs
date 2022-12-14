using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : LivingEntity
{
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
        PlayerHPManager.Instance.PlayerHelathCheck(this); //그냥 여기서 deathCount++해도 될꺼같은데
    }


}
