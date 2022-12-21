using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieDamage : MonoBehaviour
{

  
    public void Retry()
    {
        Debug.Log("다시시작");
        SceneManager.LoadScene("FinalGame");
    }


    //public void RetryPopup()
    //{
    //    gameObject.SetActive(true);
    //}
}
