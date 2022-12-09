using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSelectFrame : MonoBehaviour
{
    public Image[] playerSelect;
    public Image frame;

    public void Select(int i)
    {
        frame.rectTransform.anchoredPosition = playerSelect[i].rectTransform.anchoredPosition;
    }
}
