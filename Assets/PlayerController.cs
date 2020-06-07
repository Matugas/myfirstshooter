using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float fireRate = 1f;
    public GameObject shotPrefab;
    public Transform firePoint;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private float fireCooldown;
    private bool isFacingRight;

    void Start()
    {
        fireCooldown = fireRate;
        isFacingRight = true;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if(horizontalInput > 0 && !isFacingRight)
        {
            transform.Rotate(0, 180, 0);
            isFacingRight = true;
        }
        else if(horizontalInput < 0 && isFacingRight)
        {
            transform.Rotate(0, -180, 0);
            isFacingRight = false;
        }

        animator.SetBool("IsRunning", horizontalInput != 0);
        if (Input.GetButton("Fire1") && fireCooldown <= 0)
        {
            horizontalInput = 0;
            animator.SetTrigger("IsShooting");
            Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
            fireCooldown = fireRate;
        }
        fireCooldown -= Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJumping", true);
        }

        transform.Translate(horizontalInput * speed * Time.deltaTime, 0, 0);
    }
}
