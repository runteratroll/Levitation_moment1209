using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseManager : MonoSingleton<BaseManager>
{

    public GameObject Base;
    public Transform baseSpawnPosition;

    public void Relode()
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
       // GameObject basess =  Instantiate(Base, baseSpawnPosition.transform.position , Quaternion.identity);    
    }



}
