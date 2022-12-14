using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private SpawanData spawanData;

    [SerializeField] private GameObject[] pos;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject[] enemyPrefabI;

    public GameObject nextWaveButton;

    [SerializeField] private int stageWave = 0; // �⺻���� ���̺�
    [SerializeField] private int wave = 0; // ���� ���̺� 3�� ���� �������� ���̺� ������
    [SerializeField] private bool waveRun = false; // ���̺� �������ΰ�

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
    /// ���̺� ��ư �������� ����Ǵ³�
    /// </summary>
    public void WaveRun()
    {
        nextWaveButton.SetActive(false);
        wave = 0;
        stageWave++;
        LoadSpawnData();
    }

    /// <summary>
    /// ���̺� �������� ����
    /// </summary>
    private void Wavebool()
    {
        if (waveRun)
        {
            //���� ���°� Ȯ�ν�
            if (!IsEnemyLive())
            {
                wave++;
                LoadSpawnData();
            }
        }
    }

    private bool IsEnemyLive()
    {
        ShipEnemy checkObj;
        checkObj = FindObjectOfType<ShipEnemy>();
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
    /// ���͸� ������Ű�� �Լ�
    /// </summary>
    /// <param name="posi"> �����Ǵ� ��ǥ ���ξ� </param>
    /// <param name="prei"> �����Ǵ� �� ���ξ� </param>
    private void PosSpawn(int posi, int prei)
    {
        float x = pos[posi].transform.position.x;
        float z = pos[posi].transform.position.z;
        enemyPrefabI[prei] = Instantiate(enemyPrefab[prei], new Vector3(x, 0, z), Quaternion.identity);
        enemyPrefabI[prei].SetActive(true);
    }
}
