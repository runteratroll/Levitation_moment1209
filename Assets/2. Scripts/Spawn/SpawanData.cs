using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class SpawanData : ScriptableObject
{
    public StageData[] stageDatas;
}

[System.Serializable]
public class StageData
{
    public WaveData[] waveDatas;
}

[System.Serializable]
public class WaveData
{
    public MonsterData[] monsterDatas;
}

[System.Serializable]
public class MonsterData
{
    public int posID;
    public int enemyID;
}