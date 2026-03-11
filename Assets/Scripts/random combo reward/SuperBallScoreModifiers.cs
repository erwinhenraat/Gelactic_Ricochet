using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;

    private void OnEnable()
    {
        Debug.Log("[ScoreManager] Enabled");
        HitBumper.onHitBumper += OnBumperHit;
    }

    private void OnDisable()
    {
        Debug.Log("[ScoreManager] Disabled");
        HitBumper.onHitBumper -= OnBumperHit;
    }

    private void OnBumperHit(Transform bumper, int basePoints)
    {
        int finalPoints = basePoints;

        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null)
        {
            SuperBallMarker sb = ball.GetComponent<SuperBallMarker>();
            if (sb != null && sb.IsSuperBall)
            {
                Debug.Log("[ScoreManager] Super Ball detected → applying 100x multiplier");
                finalPoints *= 100;
            }
        }

        Debug.Log($"[ScoreManager] Adding score: {finalPoints}");
        AddScore(finalPoints);
    }

    private void AddScore(int points)
    {
        score += points;
        Debug.Log($"[ScoreManager] TOTAL SCORE: {score}");
    }
}