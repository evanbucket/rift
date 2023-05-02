using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    enum PlayerState {
        Idle,
        Moving,
        Attacking,
    }

    private PlayerState currentState = PlayerState.Idle;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private const int SPEED_UNIT = 1000;
    public float speed;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    public float damage;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentState = PlayerState.Idle;
    }

    void IdleState(Vector2 direction)
    {
        if (direction != new Vector2(0,0)){
            currentState = PlayerState.Moving;
            sr.color = Color.green;
            //Debug.Log("Time to go!");
        }
    }

    void MoveState(Vector2 direction)
    {
        if (direction == new Vector2(0,0)){
            currentState = PlayerState.Idle;
            sr.color = Color.red;
            //Debug.Log("I'm idle!");
        }
    }

    void AttackState()
    {
        // temp!!! fix please, starts 2 animations and gets stuck?
        sr.color = Color.yellow;
        //Debug.Log("ATTACK!");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && currentState != PlayerState.Attacking) {
            currentState = PlayerState.Attacking;
        }
    }   

    void FixedUpdate()
    {
        // +1 for right/up, -1 for left/down.
        // Example: Vector2(1, -1) = diagonal direction right and down.
        Vector2 direction = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        transform.position = new Vector2(
            transform.position.x + speed * direction.x / SPEED_UNIT,
            transform.position.y + speed * direction.y / SPEED_UNIT
        );

        

        // If current state is moving, the player is moving and is doing walking animation
        if (currentState == PlayerState.Moving) {
            MoveState(direction);
            animator.SetBool("isMoving", true);
            animator.SetBool("isAttacking", false);
        // If current state is idle, the player is idle, and is not doing the walking animation
        } else if (currentState == PlayerState.Idle) {
            IdleState(direction);
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", false);
        // If the current state is attacking, the player is attacking and doing the attack animation
        } else if (currentState == PlayerState.Attacking) {
            AttackState();
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", true);
        }
        
        // Flip sprite
        if (direction.x < 0) {
            this.transform.localScale = new Vector3(-0.529f, 0.427639f, 1);
        } else if (direction.x > 0) {
            this.transform.localScale = new Vector3(0.529f, 0.427639f, 1);
        }  
    }

    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);
        
        foreach (Collider2D enemyGameobject in enemy) {
            //Debug.Log("Hit enemy!");
            enemyGameobject.GetComponent<EnemyHealth>().health -= damage;
        }
    }

    public void endAttack()
    {
        animator.SetBool("isAttacking", false);
        //Debug.Log("Tired...");
        currentState = PlayerState.Moving;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
    // need to lock movement during attack!
    // change the attack animation!!
    // 6 class periods left 4/17
    // pixels per unit make thing smaller
}
