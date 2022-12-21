using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextToStart : MonoBehaviour
{
    public void TouchToStart()
    {
        SceneManager.LoadScene("FinalGame");
    }
}
