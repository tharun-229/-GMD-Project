using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public int coinValue = 1;
    public float rotationSpeed = 180f;

    void Update()
    {
        transform.Rotate(
            0f,
            rotationSpeed * Time.deltaTime,
            0f
        );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager manager =
                FindFirstObjectByType<CoinManager>();

            if (manager != null)
            {
                manager.AddCoins(coinValue);
            }

            Destroy(gameObject);
        }
    }
}