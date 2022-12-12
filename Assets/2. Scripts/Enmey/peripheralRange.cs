using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peripheralRange : MonoBehaviour
{

    private GameObject target;
    private GameObject projectile;
    //mesh를 쓸줄 알면 일일히 넣지 않아도 됨



    public peripheralRange(GameObject _target, GameObject _projectile)
    {
        target = _target;
        projectile = _projectile;


    }

 

}
