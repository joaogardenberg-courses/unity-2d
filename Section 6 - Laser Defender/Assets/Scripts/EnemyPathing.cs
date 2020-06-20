using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Start() {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update() {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig) {
        this.waveConfig = waveConfig;
    }

    private void Move() {
        if (waypointIndex <= waypoints.Count - 1) {
            Vector3 targetPosition = waypoints[waypointIndex].transform.position;

            if (transform.position == targetPosition) {
                waypointIndex++;
            } else {
                float movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;

                transform.position = Vector2.MoveTowards(
                    transform.position,
                    targetPosition,
                    movementThisFrame
                );
            }
        } else {
            Destroy(gameObject);
        }
    }
}
