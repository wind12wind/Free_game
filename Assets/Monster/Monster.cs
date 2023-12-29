using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 2.0f; // 이동 속도
    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    void Update()
    {
        // 몬스터를 아래로 이동
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        // 몬스터가 카메라 뷰포트의 하단을 벗어났는지 확인
        if (!IsInView(Camera.main, transform.position))
        {
            spawnManager.ReturnMonster(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        spawnManager.ReturnMonster(gameObject);
    }

    bool IsInView(Camera camera, Vector3 position)
    {
        Vector3 viewportPosition = camera.WorldToViewportPoint(position);
        // 몬스터가 화면의 왼쪽, 오른쪽, 위를 벗어났는지 확인
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y > -0;
    }
}


