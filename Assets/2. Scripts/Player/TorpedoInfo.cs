using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoInfo : MonoBehaviour
{
    public Transform torpedo;
    public float T;
    public AudioSource warm;
    public float distance;
    List<GameObject> FoundObjects;
    public GameObject enemy;
    public float shortDis;
    void Update()
    {
        

        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Torpedo"));
        if(FoundObjects != null)
        {
            shortDis = Vector3.Distance(gameObject.transform.position, FoundObjects[0].transform.position); // 첫번째를 기준으로 잡아주기 

        }

        enemy = FoundObjects[0]; // 첫번째를 먼저 
 
        foreach (GameObject found in FoundObjects)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);
 
            if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
            {
                enemy = found;
                shortDis = Distance;
            }
        }
        
        torpedo = GameObject.FindGameObjectWithTag("Torpedo").transform;

        distance = Vector3.Distance(enemy.transform.position, transform.position);

        if(shortDis < 20)
        {
            TimeLow();
            if(T < 0)
            {
                Debug.Log("a");
                enemy.GetComponent<AudioSource>().Play();
                //warm.Play();
                T = 0.5f;
            }
        }
        else if(shortDis < 40)
        {
            TimeLow();
            if(T < 0)
            {
                Debug.Log("b");
                enemy.GetComponent<AudioSource>().Play();
                T = 1f;
            }
        }
        
    }
    void TimeLow()
    {
        T -= 1 * Time.deltaTime;
    }
}
