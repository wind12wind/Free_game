using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 2.0f; // �̵� �ӵ�

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }
}

