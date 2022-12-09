using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{ 
    [Header("Sight Elements")] 
    public float eyeRadius = 5f;
    [Range(-360, 360)]   //음수가 되도 체크가 가능하게 하던가 양수에서 뭐뭐를 하던가
    public float eyeAngle = 90f;

    [Header("Search Elements")]
     
    public LayerMask targetLayerMask; 
    public LayerMask blockLayerMask;
     
    private List<Transform> targetLists = new List<Transform>(); 
    public Transform firstTarget; 
    private float distanceTarget = 0.0f;
     
    public List<Transform> TargetLists => targetLists;
    public Transform FirstTarget => firstTarget;
    public float DistanceTarget => distanceTarget;
    void FindTargets()
    { 
        distanceTarget = 0.0f;
        //firstTarget = null;
        targetLists.Clear();
         
        Collider[] overlapSphereTargets = Physics.OverlapSphere(transform.position, eyeRadius, targetLayerMask);
        
         
        for (int i = 0; i < overlapSphereTargets.Length; i++)
        { 
            Transform target = overlapSphereTargets[i].transform;
            Vector3 LookAtTarget = (target.position - transform.position).normalized; //back하는 법은?
            //target이 없어서 그런걸지도

            //Debug.Log("LookAtTarget 은?" + LookAtTarget);

            if (Vector3.Angle(transform.forward   , LookAtTarget) < eyeAngle / 2) //뒤쪽을 기준으로 
            {   
                float nowFirstDistanceTarget = Vector3.Distance(transform.position, target.position );
                //Debug.Log("noeDistanceTagert" + nowFirstDistanceTarget);

                if (!Physics.Raycast(transform.position, LookAtTarget, nowFirstDistanceTarget * 2, blockLayerMask))
                {
                    targetLists.Add(target);
                    if (firstTarget == null || (distanceTarget > nowFirstDistanceTarget))
                    {
                     
                        firstTarget = target;
                        distanceTarget = nowFirstDistanceTarget;

                        //Debug.Log("플레이어 감지" + firstTarget.name);
                    }

                }
            }
            
        }
    }

    public float delayFindTime = 0.2f;

    private void Update()
    {
        FindTargets();
    }
     

    void Start()
    {
        StartCoroutine("updateFindTargets", delayFindTime);
    }
     
    IEnumerator updateFindTargets(float delay) //
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindTargets();
        }
    }

    public Vector3 findTargetAngle(float degrees, bool flagGlobalAngle)
    {
        if (!flagGlobalAngle)
        {
            degrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(degrees * Mathf.Deg2Rad), 0, Mathf.Cos(degrees * Mathf.Deg2Rad));
    }
}
