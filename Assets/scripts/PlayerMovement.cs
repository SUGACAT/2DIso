using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    
    private float moveH, moveV;
    public float moveSpeed = 2.0f;

    private Animator anim;
    
    private SpriteRenderer characterRenderer;

    public int health = 100;
    public TextMeshProUGUI hp_txt;

    public GameObject deathObj;
    public bool isDead;

    public LayerMask rayMask;

    public bool isAttacking = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        characterRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) return;
        
        moveH = Input.GetAxisRaw("Horizontal");
        moveV = Input.GetAxisRaw("Vertical");

        if (moveH > 0)
        {
            characterRenderer.flipX = false;
        }
        else if(moveH < 0)
        {
            characterRenderer.flipX = true;
        }

        if (Mathf.Abs(rb.velocity.y) > 0)
        {
            anim.SetBool("Direction", true);

        }
        else
        {
            anim.SetBool("Direction", false);
        }

        if (health <= 0)
        {
            deathObj.SetActive(true);
            isDead = true;
        }

        Attack();
        ShootRazor();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV).normalized * moveSpeed;
    }
    
    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Attack", true);
            isAttacking = true;
                
        }
        else if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Attack", false);
            isAttacking = false;
        }
    }

    void ShootRazor()
    {
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Tree"))
        {
            health--;
            hp_txt.text = "HP : " + health.ToString();
        }
    }
}
