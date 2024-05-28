using UnityEngine;
using UnityEngine.SceneManagement;

namespace Singleton
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance => instance;
        private static GameManager instance;

        private int score = 0;
        private string level2 = "Level2";
        private Player playerInstance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else //Instance != null
            {
                Destroy(gameObject);
            }
        }

        public void AddPoints(int points)
        {
            score += points;
            Debug.Log($"Current score {score}");
            if (score >= 100)
            {
                LoadLevelAsync(level2);
                score = 0;
            }
        }

        public Player GetPlayerInstance()
        {
            return playerInstance;
        }

        public void LoadLevel(string sceneToLoad)
        {
            //Cargar con indice//
            //Cargar con Nombre//
            SceneManager.LoadScene(sceneToLoad);
        }

        public void LoadLevel(int levelIndex)
        {
            SceneManager.LoadScene(levelIndex);
        }

        public void LoadLevelAdditive(string sceneToLoad)
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
        }

        public void LoadLevelAsync(string sceneToLoad)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
            while (asyncLoad.progress < 0.9)
            {
                Debug.Log($"Progress: {asyncLoad.progress * 100}");
            }
        }

        public void DestroyAllCollectables(float playerHealthLeft)
        {
            // playerInstance.OnDeath -= DestroyAllCollectables;
            playerInstance.OnDeathUnity.RemoveListener(DestroyAllCollectables);
            Debug.Log("Player is dead");
        }

        public void PlayerCreated(Player player)
        {
            playerInstance = player;
            // player.OnDeathUnity.AddListener(DestroyAllCollectables);
            // player.OnDeath += DestroyAllCollectables;
        }
    }
}