using UnityEngine;
using System;

public class HazardObject : MonoBehaviour
{
    public static event Action onBallDestroyed;
    private float timer = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        //transform.position += transform.right * Time.deltaTime * 17;

        if (timer > 4f)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            onBallDestroyed?.Invoke();
            Destroy(collision.gameObject);
            Debug.Log("test2");
        }

        Debug.Log("test1");
    }

    
}
