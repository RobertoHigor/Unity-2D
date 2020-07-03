using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // O que importa é apenas a posição (transform) dos waypoints
    WaveConfig waveConfig;
    List<Transform> waypoints;

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

    public void SetWaveConfig(WaveConfig wave)
    {
        this.waveConfig = wave;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {// Se não chegou no último waypoint
            // Onde ir e o quão rápido
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;

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
