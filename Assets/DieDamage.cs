using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieDamage : MonoBehaviour
{
    public static DieDamage  instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        gameObject.SetActive(false);




    }
    public void Retry()
    {
        Debug.Log("다시시작");
        SceneManager.LoadScene("SeungHoon2");
    }


    public void RetryPopup()
    {
        gameObject.SetActive(true);
    }
}
