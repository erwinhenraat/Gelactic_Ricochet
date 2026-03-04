using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action onReadyToRestart;
    private bool waitForHighScoreInitials = false;
    [SerializeField] private CrosshairInput crosshairInput;
    [SerializeField] private Aim aim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score.onHighScoreBrokenAtPlay += OnHighScoreBroken;
        Lives.onGameOver += OnGameOver;

       // crosshairInput = FindAnyObjectByType<CrosshairInput>();
       // aim = FindAnyObjectByType<Aim>();

    }
    private void OnDisable()
    {
        Score.onHighScoreBrokenAtPlay -= OnHighScoreBroken;
        Lives.onGameOver -= OnGameOver;
    }

    private void OnHighScoreBroken() {
        waitForHighScoreInitials = true;
    }
    private void OnGameOver(string _) {

        if (!waitForHighScoreInitials) {           

            onReadyToRestart?.Invoke();
            return;
        }
        SelectInitials.onInitialsSubmitted += OnHighScoreSubmitted;
        Debug.Log("disable crosshair input and aim");
        crosshairInput.enabled = false;
        aim.enabled = false;

    }
    private void OnHighScoreSubmitted(string _) {
        SelectInitials.onInitialsSubmitted -= OnHighScoreSubmitted;
        waitForHighScoreInitials = false;
        onReadyToRestart?.Invoke();

        crosshairInput.enabled = true;
        aim.enabled = true;
    }
}
