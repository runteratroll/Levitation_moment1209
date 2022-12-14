using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class FieldofCollider : MonoBehaviour
{
    [Header("RotationConstraint 추가하기!!!")]

    public LookAtPlayer lookAtPlayer;
    public Transform target; 


    private void Awake()
    {
        //Debug.Log("LookAtPlayerCheck");
        

        // for(int i = 0; i < transform.childCount; i++)
        // {
        //     transform.GetChild(i).gameObject.AddComponent<FieldofCollider>(); 
        // }
    }
    
    private void Start()
    {
        lookAtPlayer = transform.parent.GetComponentInParent<LookAtPlayer>();
    }

    private void OnTriggerStay(Collider other)
    {
      
        if (other.CompareTag("Player"))
        {

            //�Ƹ��� taret�� �ִ� �ٷ� ������ϱ� �׷��žƴұ�?
            target = other.transform;
            Debug.Log("Ʈ���� ����" + other.gameObject.name);

            if(lookAtPlayer != null)
            {
                lookAtPlayer.LookPlayer();
            }
   




            //���⿡ ��� �ڵ�
            //������ ��� �ڵ� 
            //������ �ߴٴ� �� �˸��� �ڵ� 
            // �������� ����Ʈ�� ������ �� �ϴ� �ڵ�, 
            //�Ѿ˱���ü�� �߻��ڵ� ��� �ڵ� �ֱ�
            // �׸��� ��Ÿ�Ӹ��� ��� �ڵ� ����� TIme.time�ϱ�
            //��Ÿ�Ӿ����� ������ �̰� ���� �Լ�ȭ ��Ű�� ���� ������? 
            //FUncitonTImer�ϸ� ������ �̰� �ݺ��ϸ� �Ǳ��ϴµ�, ��� ���������� ���� ������ ������
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        //target = null;
    }
}
