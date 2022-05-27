using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private Vector3 mousePos;
    private Rigidbody2D rb;
    private Vector2 position = new Vector2(0, 0);

    [SerializeField] private float moveSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Get screen mouse position
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        position = Vector2.Lerp(transform.position, mousePos, moveSpeed / 10);

        //Rotate fishe
        var offset = new Vector2(mousePos.x - position.x, mousePos.y - position.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void FixedUpdate()
    {
        //Move rigidbody
        rb.MovePosition(position);
    }
}
