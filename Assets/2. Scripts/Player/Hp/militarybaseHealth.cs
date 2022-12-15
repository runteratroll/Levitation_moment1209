using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class militarybaseHealth : LivingEntity {

    private void Awake()
    {

        dead = false;

    }
    public override void Die()
    {

        
        BaseManager.Instance?.MilitaryBaseCheck(this);

        //SceneManager.LoadScene("SeungHoon2");
    }

    public override void setDmg(int dmg, GameObject prefabEffect)
    {

        if (!getFlagLive)
        {
            //데미지 처리 안함 
            return;
        }

        //안 죽었다면, 현재 hp에서 데미지를 차감 해준다 
        currentHealth -= dmg;
        hpBar.hp -= (float)dmg; //내가 참조하고 있는 HpBar에 Hp를 줄인다. 
        //healthSystem.Damage(dmg);



        //if (atkEffectPrefab)
        //{
        //    Instantiate(atkEffectPrefab, weaponHitTransform); //데미지 줄떄, 어펙트이펙트도 주네
        //    //weaponHitTransform는  변수를 클래스 변수 쪽에 추가하고 돌아온다
        //    //칼을 맞았다 할 때 칼의 위치
        //    //힙을 설정 
        //}

        //데미지 차감 하고 0 이하가 되면 죽은 상태가 되겠지
        //근데 데미지 차감해도 살아 있는 상태면 
        if (getFlagLive)
        {

        }
        else
        {
            //죽은 상태면 stateDie로 상태 전환 
            //fsmManager.ChangeState<stateDie>(); //
            Die();
        }
    }



}
