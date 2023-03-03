using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField] float speed = 10;

    [SerializeField] float buttonTime;
    [SerializeField] float jumpHeight = 3, jumpTime = 1, cancelRate = 100, jumpDistance = 0.1f;
    private bool jumping, jumpCancelled;

    public LayerMask ground;
    public bool isGrounded;

    private Rigidbody2D rb;

    private float screenWidth;
    private float direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenWidth = mainCamera.aspect*mainCamera.orthographicSize-transform.localScale.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(transform.position, Vector2.down, jumpDistance, ground)){
            isGrounded = true;
        }
        else {
            isGrounded = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
        }
        if (jumping){

            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))  jumpCancelled = true;
            if (jumpTime > buttonTime) jumping = false;
            
        }

        direction = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if(jumpCancelled && jumping && rb.velocity.y > 0 && !isGrounded)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }

        if(transform.position.x>screenWidth && direction>0 || transform.position.x<-screenWidth && direction<0){
            rb.velocity = new Vector2(0,rb.velocity.y);
            return;
        }
        rb.velocity =new Vector2(speed*direction * Time.deltaTime, rb.velocity.y);
    }
}
