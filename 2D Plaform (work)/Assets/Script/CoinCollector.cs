using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private int _amountCoins = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _amountCoins += coin.Value;
            Destroy(coin.gameObject);

        }
    }
}
