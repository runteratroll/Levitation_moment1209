using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public abstract class AtkBehaviour : MonoBehaviour
{

    

#if UNITY_EDITOR
    [Multiline]
    public string devComment = ""; 
    
#endif  // UNITY_EDITOR 
    public int aniMotionIdx; 
    public int importanceAtkNo; 
    public int atkDmg =  10; 
    public float atkRange = 70f;

    [SerializeField]
    private float atkCoolTime;
    [SerializeField]
    private float atkCoolTimeMinuse;
    protected float nowAtkCoolTime = 0.0f;     
    public GameObject atkEffectPrefab; 
    public LayerMask targetLayerMask;  

    [SerializeField]
    public bool IsAvailable => (nowAtkCoolTime >= atkCoolTime); //IsAvailable => (now
    [SerializeField]
    public bool IsAvailableBefore => (nowAtkCoolTime >= atkCoolTime - atkCoolTimeMinuse);

    protected virtual void Start()
    { 
        nowAtkCoolTime = atkCoolTime; //����, ����
    }




    // Update is called once per frame
    protected void Update()
    {
       
        if (nowAtkCoolTime < atkCoolTime) //���⼭ ���� ��Ÿ�����ְ�
        {    
            nowAtkCoolTime += Time.deltaTime;
        }  
    }
     
    public abstract void callAtkMotion(GameObject target = null, Transform posAtkStart = null); // callAtkMotion 

} 