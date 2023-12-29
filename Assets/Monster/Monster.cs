using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 2.0f; // �̵� �ӵ�
    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    void Update()
    {
        // ���͸� �Ʒ��� �̵�
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        // ���Ͱ� ī�޶� ����Ʈ�� �ϴ��� ������� Ȯ��
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
        // ���Ͱ� ȭ���� ����, ������, ���� ������� Ȯ��
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y > -0;
    }
}


