using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] monsterPrefabs; // 몬스터 프리팹 배열
    public float spawnInterval = 2.0f; // 스폰 간격
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
            // 풀이 비었을 경우, 새로운 몬스터 생성 (선택적)
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

        // 스폰 위치 계산
        Vector3 spawnPosition = CalculateSpawnPosition();
        monster.transform.position = spawnPosition;
    }

    Vector3 CalculateSpawnPosition()
    {
        Camera mainCamera = Camera.main;
        Vector3 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1, mainCamera.nearClipPlane));
        spawnPosition.z = -10; // 2D 게임인 경우 Z 좌표 조정
        return spawnPosition;
    }
}
