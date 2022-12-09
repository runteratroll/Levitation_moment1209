using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private SpawanData spawanData;

    [SerializeField] private GameObject[] pos;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject[] enemyPrefabI;

    public GameObject nextWaveButton;

    [SerializeField] private int stageWave = 0; // 기본적인 웨이브
    [SerializeField] private int wave = 0; // 작은 웨이브 3번 깨면 스테이지 웨이브 증가됨
    [SerializeField] private bool waveRun = false; // 웨이브 실행중인가

    private void Awake()
    {
        stageWave = -1;
        wave = -1;
    }

    private void Update()
    {
        Wavebool();
    }

    /// <summary>
    /// 웨이브 버튼 눌렀을때 실행되는놈
    /// </summary>
    public void WaveRun()
    {
        nextWaveButton.SetActive(false);
        wave = 0;
        stageWave++;
        LoadSpawnData();
    }

    /// <summary>
    /// 웨이브 전반적을 관리
    /// </summary>
    private void Wavebool()
    {
        if (waveRun)
        {
            //적이 없는걸 확인시
            if (!IsEnemyLive())
            {
                wave++;
                LoadSpawnData();
            }
        }
    }

    private bool IsEnemyLive()
    {
        Move checkObj;
        checkObj = FindObjectOfType<Move>();
        if(checkObj == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void LoadSpawnData()
    {
        if (wave == 4)
        {
            waveRun = false;
            nextWaveButton.SetActive(true);
        }

        else
        {
            for (int i = 0; i < spawanData.stageDatas[stageWave].waveDatas[wave].monsterDatas.Length; i++)
            {
                Debug.Log(i);
                PosSpawn(
                    spawanData.stageDatas[stageWave].waveDatas[wave].monsterDatas[i].posID,
                    spawanData.stageDatas[stageWave].waveDatas[wave].monsterDatas[i].enemyID
                );
            }

            waveRun = true;
        }
    }

    /// <summary>
    /// 몬스터를 스폰시키는 함수
    /// </summary>
    /// <param name="posi"> 스폰되는 좌표 라인업 </param>
    /// <param name="prei"> 스폰되는 적 라인업 </param>
    private void PosSpawn(int posi, int prei)
    {
        float x = pos[posi].transform.position.x;
        float z = pos[posi].transform.position.z;
        enemyPrefabI[prei] = Instantiate(enemyPrefab[prei], new Vector3(x, 0, z), Quaternion.identity);
    }
}
