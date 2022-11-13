 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float moveForce = 10f;
    [SerializeField]
    public float jumpFroce = 11f;

    private float movementX;
    private Rigidbody2D myRigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private string WALK_ANIMATION = "isWalk";

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        AnimatePlayer();
    }

    void PlayerMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        //Debug.Log("deltaTime is " + Time.deltaTime);
    }

    void AnimatePlayer()
    {
        bool isWalking = movementX != 0f;
        animator.SetBool(WALK_ANIMATION, isWalking);
        bool shouldFlipX = movementX < 0f;
        spriteRenderer.flipX = shouldFlipX;
    }
}
