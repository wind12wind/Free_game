using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] monsterPrefabs; // ���� ������ �迭
    public float spawnInterval = 2.0f; // ���� ����
    public int poolSize = 10;
    private Queue<GameObject> monsterPool = new Queue<GameObject>();

    void Start()
    {
        InvokeRepeating("SpawnMonster", spawnInterval, spawnInterval);
        for (int i = 0; i < poolSize; i++)
        {
            int monsterIndex = Random.Range(0, monsterPrefabs.Length);
            GameObject monsterPrefab = monsterPrefabs[monsterIndex];

            GameObject monster = Instantiate(monsterPrefab);
            monster.SetActive(false);
            monsterPool.Enqueue(monster);
        }
    }

    public GameObject GetMonster()
    {
        if (monsterPool.Count > 0)
        {
            GameObject monster = monsterPool.Dequeue();
            monster.SetActive(true);
            return monster;
        }
        else
        {
            // Ǯ�� ����� ���, ���ο� ���� ���� (������)
            int monsterIndex = Random.Range(0, monsterPrefabs.Length);
            GameObject monsterPrefab = monsterPrefabs[monsterIndex];
            GameObject monster = Instantiate(monsterPrefab);
            return monster;
        }
    }

    public void ReturnMonster(GameObject monster)
    {
        monster.SetActive(false);
        monsterPool.Enqueue(monster);
    }

    void SpawnMonster()
    {
        GameObject monster = GetMonster();

        // ���� ��ġ ���
        Vector3 spawnPosition = CalculateSpawnPosition();
        monster.transform.position = spawnPosition;
    }

    Vector3 CalculateSpawnPosition()
    {
        Camera mainCamera = Camera.main;
        Vector3 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1, mainCamera.nearClipPlane));
        spawnPosition.z = -10; // 2D ������ ��� Z ��ǥ ����
        return spawnPosition;
    }
}
