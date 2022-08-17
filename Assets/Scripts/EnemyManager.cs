using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // ������Ʈ Ǯ ũ��
    public int poolSize = 10;

    // ������Ʈ Ǯ �迭
    public List<GameObject> enemyObjectPool;

    // SpawnPoint
    public Transform[] spawnPoints;

    // �� ����
    public GameObject enemyFactory;

    // �� ���� �ּҽð�
    float minTime = 0.5f;

    // �� ���� �ִ�ð�
    float maxTime = 1.5f;

    // �����ð�
    float currentTime = 0;
    float createTime;

    public void Start()
    {
        //createTime = UnityEngine.Random.Range(minTime, maxTime);
        createTime = Random.Range(minTime, maxTime);

        // ������Ʈ Ǯ�� ���� ������ �ִ� ũ��� �����.
        enemyObjectPool = new List<GameObject>();

        // ������Ʈ Ǯ�� ���� ������ ��ŭ �ݺ��Ѵ�.
        for(int i = 0; i < poolSize; i++)
        {
            // ������ ���忡�� ���� �����Ѵ�.
            GameObject enemy = Instantiate(enemyFactory);

            // ���� ������Ʈ Ǯ�� �ִ´�.
            enemyObjectPool.Add(enemy);

            // ��Ȱ��ȭ
            enemy.SetActive(false);
        }
    }

    public void Update()
    {
        // �ð��� �帣��.
        currentTime += Time.deltaTime;

        // �����ð��� �Ǹ�
        if (currentTime > createTime)
        {
            // ������ƮǮ���� ���� �����ͼ� ���
            GameObject enemy = enemyObjectPool[0];

            // ������ƮǮ�� ���� �ִٸ�
            if (enemyObjectPool.Count > 0)
            {
                // ���� Ȱ��ȭ �ϰ� �ʹ�.
                enemy.SetActive(true);

                // ������ƮǮ���� �Ѿ�����
                enemyObjectPool.Remove(enemy);

                // �������� �ε��� ����
                int index = Random.Range(0, spawnPoints.Length);

                // �� ��ġ��Ű��
                enemy.transform.position = spawnPoints[index].position;                
            }

            createTime = Random.Range(minTime, maxTime);
            currentTime = 0;
        }
    }
}
