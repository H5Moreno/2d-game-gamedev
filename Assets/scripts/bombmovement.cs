using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;  // Speed at which the enemy moves
    public float moveDistance = 5f;  // How far the enemy will move in each direction (left to right or up and down)

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;  // Save the initial position of the enemy
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    // Function to move the enemy back and forth
    void MoveEnemy()
    {
        // Calculate the new position using PingPong to move back and forth
        float movement = Mathf.PingPong(Time.time * moveSpeed, moveDistance);

        // Update the position of the enemy on the X-axis (for left-right movement)
        transform.position = new Vector3(startPosition.x + movement, transform.position.y, transform.position.z);
    }
}
