using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    public int damage;
    public int realDam;
    public GameObject target;
    void Start()
    {
        realDam = Random.Range((int)(damage * 0.8f), (int)(damage * 1.2f));
        Destroy(gameObject, 10f);

       
  
    }
    protected virtual void Update()
    {
        transform.Translate((Vector3.forward ) * Time.deltaTime * speed);
    }
    protected virtual void OnProjectileStartCollision(Collider other)
    {
        

        IDmgAble iDmgAble = other.gameObject.GetComponent<IDmgAble>();

        if (iDmgAble != null)
        {
            //Debug.Log("���� ������");
            iDmgAble.setDmg(realDam, null); //atk ������ �� �ʿ����?
            DamagePopup.Create(other.transform.position, realDam, false);

            Debug.Log("삭제되니?");
            Destroy(gameObject);
            //for문으로 
            //�׷��� �÷��̾�� MonsterFsm�� attackBehaviour�� �����ݾ� �׷��� �׷��� 0�̴ϱ� �ȹٲ�ſ���
        }

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        return;


        
        Debug.Log("OntriggerEnter Bullet");
        OnProjectileStartCollision(other);

    }
}
