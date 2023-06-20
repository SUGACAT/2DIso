using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private PlayerMovement thePlayerMove;
    
    // Start is called before the first frame update
    void Start()
    {
        thePlayerMove = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Tree"))
        {
            if (thePlayerMove.isAttacking)
            {
                Destroy(other.gameObject);
            }
        }
            
    }
}
