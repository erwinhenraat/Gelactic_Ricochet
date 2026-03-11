public interface IComboReward
{
    int RequiredCombo { get; }
    void ActivateReward(string tag);
    void ResetReward();
}