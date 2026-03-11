using UnityEngine;
using System;

public class ExtraBall : MonoBehaviour, IComboReward
{
    public static event Action<string> onExtraBall;

    [SerializeField] private int requiredCombo = 10;

    public int RequiredCombo => requiredCombo;

    public void ActivateReward(string _)
    {
        Debug.Log("[ExtraBall] Extra Ball Granted!");
        onExtraBall?.Invoke("Extra Life");
    }

    public void ResetReward()
    {
        // No reset needed for extra ball
    }
}