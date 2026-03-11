using UnityEngine;

public class SuperBallMarker : MonoBehaviour
{
    public bool IsSuperBall { get; private set; }

    public void Enable()
    {
        IsSuperBall = true;
        Debug.Log("[SuperBallMarker] Ball is now SUPER BALL");
    }

    public void Disable()
    {
        IsSuperBall = false;
        Debug.Log("[SuperBallMarker] Ball returned to NORMAL");
    }
}