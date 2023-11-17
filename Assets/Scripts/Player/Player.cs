using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 5;
    private Vector2 _moveDirection;

    [SerializeField] private float jumpForce = 9;

    private bool isGrounded;
    private float depth;
    
    private Rigidbody2D rb;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public float inputHorizontal;
    
    
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
        
        InputManager.SetGameControls();

        rb = GetComponent<Rigidbody2D>();
        depth = GetComponent<Collider2D>().bounds.size.y;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(speed * Time.deltaTime * _moveDirection);

        inputHorizontal = Input.GetAxisRaw(("Horizontal"));
        
        if (inputHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            
        }
        if (inputHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            
        }
        
        checkGround();
        
    }


    public void SetMovementDirection(Vector2 currentDirection)
    {
        _moveDirection = currentDirection;
    }

    public void jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void checkGround()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
    }
}
