using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    private int direction = 1; // 1 or -1

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolDestination].position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, patrolPoints[patrolDestination].position) < .2f) {
            if (patrolDestination == patrolPoints.Length - 1 || patrolDestination == 0 && direction == -1) {
                direction = -direction;
            }
            patrolDestination += direction;             
        }
 

        // if (patrolDestination == 1) {
        //     transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
        //     if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f) {
        //         patrolDestination = 0;
        //     }
        // }
    }
}
