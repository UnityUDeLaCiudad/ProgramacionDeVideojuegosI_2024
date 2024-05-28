using Singleton;
using UnityEngine;

namespace Collectables
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int points;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ChNonPBR player))
            {
                var gameManager = GameManager.Instance;
                gameManager.AddPoints(points);
                Destroy(gameObject);
            }
        }
    }
}