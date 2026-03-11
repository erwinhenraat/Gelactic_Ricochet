using UnityEngine;
using System.Collections;

public class SuperBallReward : MonoBehaviour, IComboReward
{
    [SerializeField] private int requiredCombo = 10;
    [SerializeField] private float duration = 10f;

    public int RequiredCombo => requiredCombo;

    private bool active;
    private Coroutine routine;

    public void ActivateReward(string _)
    {
        if (active) return;

        active = true;
        Debug.Log("[SuperBallReward] Super Ball ACTIVATED");

        routine = StartCoroutine(Timer());
    }

    public void ResetReward()
    {
        if (!active) return;

        active = false;
        Debug.Log("[SuperBallReward] Super Ball DEACTIVATED");

        if (routine != null)
            StopCoroutine(routine);
    }

    private IEnumerator Timer()
    {
        Debug.Log($"[SuperBallReward] Timer started ({duration} seconds)");
        yield return new WaitForSeconds(duration);
        ResetReward();
    }

    public bool IsActive() => active;
}