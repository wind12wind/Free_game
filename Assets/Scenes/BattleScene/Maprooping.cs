using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maprooping : MonoBehaviour
{
    public Transform tilemapTransform;
    public float tilemapHeight;
    public float scrollingSpeed;

    void Update()
    {
        if (tilemapTransform.position.y <= -tilemapHeight)
        {
            Vector3 newPos = tilemapTransform.position;
            newPos.y += tilemapHeight * 2;
            tilemapTransform.position = newPos;
        }

        tilemapTransform.position += Vector3.down * scrollingSpeed * Time.deltaTime;
    }
}
