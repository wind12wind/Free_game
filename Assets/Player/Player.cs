using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public GameObject inventoryUI;
    private Rigidbody2D rb;
    private bool isInventoryOpen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inventoryUI.SetActive(false);
    }

    void Update()
    {
        // 수평 이동 (X축)
        float moveX = Input.GetAxis("Horizontal");
        // 수직 이동 (Y축)
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * moveSpeed;

        if (moveX > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1); // 오른쪽을 바라봄
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1); // 왼쪽을 바라봄
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.instance.ToggleInventory();
        }
    }

    private void Interact()
    {
        // 상호작용 로직 구현
        Debug.Log("Interacted");
    }
}

