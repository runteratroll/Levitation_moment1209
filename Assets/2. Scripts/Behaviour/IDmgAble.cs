using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public interface IDmgAble 
{ 
    bool getFlagLive
    {
        get;
    }
        
    void setDmg(int dmg, GameObject prefabEffect);
}
