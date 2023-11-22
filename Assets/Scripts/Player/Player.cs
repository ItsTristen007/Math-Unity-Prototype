using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject powerup;

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

    private static string[] PUQueue = new string[6];
    private GameObject[] PUFollow = new GameObject[PUQueue.Length];
    
    
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            AddPowerUp(other.gameObject.name);
            Destroy(GameObject.Find(other.gameObject.name));
        }
    }

    private void AddPowerUp(string name)
    {
        for (int i = 0; i < PUQueue.Length; i++)
        {
            if (PUQueue[i] == null)
            {
                PUQueue[i] = name;
                PUFollow[i] = Create(name, i+1);
                break;
            }
        }
    }

    private GameObject Create(string name, int spot)
    {
        Debug.Log(spot);
        GameObject obj = Instantiate(powerup, new Vector3(0,0, -1), Quaternion.identity);
        PowerUp pu = obj.GetComponent<PowerUp>();
        pu.name = name;
        pu.SetSpot(spot);
        pu.Activate();
        return obj;
    }

    private void UsePowerUp()
    {
        for (int i = PUQueue.Length-1; i < PUQueue.Length; i--)
        {
            if (PUQueue[i] != null)
            {
                switch (PUQueue[i])
                {
                    case "cookie":
                        
                        break;
                }

                break;
            }
        }
    }
}
