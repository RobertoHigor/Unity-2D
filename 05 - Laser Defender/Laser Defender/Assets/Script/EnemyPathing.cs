using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // O que importa é apenas a posição (transform) dos waypoints
    [SerializeField] WaveConfig waveConfig;
    List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0; // Waypoint atual

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {// Se não chegou no último waypoint
            // Onde ir e o quão rápido
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(
                transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {// Checar se chegou no alvo
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
