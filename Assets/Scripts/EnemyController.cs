using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    enum EnemyState {
        Idle,
        Moving
    }
    private EnemyState currentState = EnemyState.Moving;
    private SpriteRenderer sr;
    // private Animator animator;

    // Stuff for becoming active when player is in range. I'm not sure if this is necessary.
    // the value we found in the Debug.Log above. (check the tutorial for details? you'll probably want to change the number, not sure though)
    /* private const float SIGHT_DISTANCE = 11.1f; */

    // The two points that the Enemy will move between in the Moving state.
    private const float RIGHT_MAX = 16.5f;
    private const float LEFT_MAX = 5.5f;

    private int direction = -1;
    private float xSpeed = 0.2f;

    public GameObject player;

   /*  void IdleState(float distance)
    {
        sr.color = Color.black;

        // Switch to moving if in sight range
        if (distance <= SIGHT_DISTANCE) {
            currentState = EnemyState.Moving;
        }
    } */

    void MovingState(float distance)
    {
        /* sr.color = Color.yellow; */

        // move back and forth
        if (transform.position.x >= RIGHT_MAX) {
            direction = -1;
        } else if (transform.position.x <= LEFT_MAX) {
            direction = 1;
        }
        transform.position = new Vector3(transform.position.x + direction * xSpeed, transform.position.y, transform.position.z);

        // switch to idle if out of sight range
        /* if (distance > SIGHT_DISTANCE) {
            currentState = EnemyState.Idle;
        } */
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Includes animation parameters
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        /* if (currentState == EnemyState.Idle) {
            IdleState(distance);
            // animator.SetBool("Moving", false);
        } else  */if (currentState == EnemyState.Moving) {
            MovingState(distance);
            // animator.SetBool("Moving", true);
        }
    }
}
