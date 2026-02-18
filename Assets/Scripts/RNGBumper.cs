using System;
using UnityEngine;

public class RNGHitBumper : MonoBehaviour
{
    [SerializeField] private int minValue = 100;
    [SerializeField] private int maxValue = 100000;

    private ParticleSystem ps;
    public static event Action<Transform, int> onHitBumper;
    

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps?.Stop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Bumper Hit!");
            Debug.Log(onHitBumper == null ? "Nobody listening" : "Someone listening");

            int randomValue = UnityEngine.Random.Range(minValue, maxValue + 1);
            onHitBumper?.Invoke(transform, randomValue);

            ps?.Play();
        }
    }
}

