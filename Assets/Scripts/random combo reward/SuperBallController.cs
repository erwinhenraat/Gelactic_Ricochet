using UnityEngine;

public class SuperBallController : MonoBehaviour
{
    private SuperBallReward reward;
    private SuperBallMarker marker;

    private void Start()
    {
        reward = FindObjectOfType<SuperBallReward>();
        marker = GetComponent<SuperBallMarker>();

        Debug.Log("[SuperBallController] Initialized");
    }

    private void Update()
    {
        if (reward == null || marker == null) return;

        if (reward.IsActive() && !marker.IsSuperBall)
        {
            Debug.Log("[SuperBallController] Enabling Super Ball on ball");
            marker.Enable();
        }
        else if (!reward.IsActive() && marker.IsSuperBall)
        {
            Debug.Log("[SuperBallController] Disabling Super Ball on ball");
            marker.Disable();
        }
    }
}