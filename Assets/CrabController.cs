using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabController : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 walkDirection = Vector3.right;
    private bool isFacingRight;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(walkDirection * speed * Time.deltaTime);
        animator.SetBool("isWalking", walkDirection.x != 0);
        if(walkDirection.x > 0 && !isFacingRight)
        {
            isFacingRight = true;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(walkDirection.x < 0 && isFacingRight)
        {
            isFacingRight = false;
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        walkDirection = Vector3.right * -1;
    }
}
