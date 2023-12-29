using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Definitions
    Rigidbody2D playerRB;
    Animator playerAnimator;

    public float moveSpeed = 1f;
    public float jumpSpeed = 1f;
    public float jumpFrequency = 1f;
    public float nextJumpTime;

    bool facingRight = true;
    public bool isGrounded = false;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        // Animator bulunamazsa hata mesajýný yazdýr
        if (playerAnimator == null)
        {
            Debug.LogError("Animator bileþeni bulunamadý!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        OnGroundCheck();

        // Change character direction
        if (playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if(playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
        
        // Is it on the floor ?
        if(Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }

    void HorizontalMove()
    {
        // Horizontal Move
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        // Parameters Update
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));

    }

    void FlipFace()
    {
        facingRight = !facingRight;

        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f,jumpSpeed));
    }
    
    void OnGroundCheck()
    {
        isGrounded =Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }

}
