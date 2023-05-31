using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed;

    IDeltaMove inputController;
    Rigidbody2D rb;



    private void Start()
    {
        inputController = GetComponent<IDeltaMove>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputController.deltaMove.normalized * speed * Time.fixedDeltaTime);
    }
}
