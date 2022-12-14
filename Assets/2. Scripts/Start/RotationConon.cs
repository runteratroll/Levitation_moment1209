using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RotationConon : MonoBehaviour
{
    private void Start()
    {
        RotationConstraint ros = transform.GetComponent<RotationConstraint>();
        ros.weight = 1;
    }
}
