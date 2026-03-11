using System.Collections.Generic;
using UnityEngine;

public class ComboRewardManager : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> rewardBehaviours;
    private readonly List<IComboReward> rewards = new();

    private void Awake()
    {
        foreach (var behaviour in rewardBehaviours)
        {
            if (behaviour is IComboReward reward)
            {
                rewards.Add(reward);
                Debug.Log($"[ComboRewardManager] Registered reward: {behaviour.name}");
            }
            else
            {
                Debug.LogError($"{behaviour.name} does not implement IComboReward");
            }
        }
    }

    private void OnEnable()
    {
        Debug.Log("[ComboRewardManager] Enabled");
        Combo.onComboAchieved += HandleCombo;
        Combo.onComboLost += ResetAllRewards;
        PlayArea.onBallLost += ResetAllRewards;
    }

    private void OnDisable()
    {
        Debug.Log("[ComboRewardManager] Disabled");
        Combo.onComboAchieved -= HandleCombo;
        Combo.onComboLost -= ResetAllRewards;
        PlayArea.onBallLost -= ResetAllRewards;
    }

    private void HandleCombo(int comboLevel, string tag)
    {
        Debug.Log($"[ComboRewardManager] Combo achieved: {comboLevel}, Tag: {tag}");

        foreach (var reward in rewards)
        {
            if (comboLevel == reward.RequiredCombo)
            {
                Debug.Log($"[ComboRewardManager] Activating reward at combo {comboLevel}");
                reward.ActivateReward(tag);
            }
        }
    }

    private void ResetAllRewards(int _, string __)
    {
        Debug.Log("[ComboRewardManager] Resetting all rewards");
        ResetAllRewards();
    }

    private void ResetAllRewards()
    {
        foreach (var reward in rewards)
            reward.ResetReward();
    }
}
