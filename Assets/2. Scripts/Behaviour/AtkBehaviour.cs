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
    public float atkRange = 3f;

    [SerializeField]
    private float atkCoolTime;                  
    protected float nowAtkCoolTime = 0.0f;     
    public GameObject atkEffectPrefab; 
    public LayerMask targetLayerMask;  

    [SerializeField]
    public bool IsAvailable => (nowAtkCoolTime >= atkCoolTime); //IsAvailable => (now

    protected virtual void Start()
    { 
        nowAtkCoolTime = atkCoolTime; //없다, 엄마
    }




    // Update is called once per frame
    protected void Update()
    {
       
        if (nowAtkCoolTime < atkCoolTime) //여기서 이제 쿨타임해주고
        {    
            nowAtkCoolTime += Time.deltaTime;
        }  
    }
     
    public abstract void callAtkMotion(GameObject target = null, Transform posAtkStart = null); // callAtkMotion 
      

} 