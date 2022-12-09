using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldofCollider : MonoBehaviour
{


    public LookAtPlayer lookAtPlayer;
    public Transform target; //�̰� �ٸ������ �˼��ְ�


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
        target = null;
    }
}
