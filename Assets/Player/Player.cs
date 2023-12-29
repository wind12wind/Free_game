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
        // ���� �̵� (X��)
        float moveX = Input.GetAxis("Horizontal");
        // ���� �̵� (Y��)
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * moveSpeed;

        if (moveX > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1); // �������� �ٶ�
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1); // ������ �ٶ�
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
        // ��ȣ�ۿ� ���� ����
        Debug.Log("Interacted");
    }
}

