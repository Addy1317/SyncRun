using UnityEngine;

namespace SyncRun.Spawn
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] obstacles;
        public GameObject[] coins;
        public float spawnDistance = 30f;
        public float interval = 1.5f;

        private float timer;

        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                SpawnRow();
                timer = 0f;
            }
        }

        void SpawnRow()
        {
            int lane = Random.Range(0, 3);
            float laneX = (lane - 1) * 3;

            Vector3 spawnPos = new Vector3(laneX, 0, transform.position.z + spawnDistance);
            Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, Quaternion.identity);

            // Random chance to spawn coin
            if (Random.value > 0.5f)
            {
                Vector3 coinPos = spawnPos + Vector3.up * 1.5f;
                Instantiate(coins[Random.Range(0, coins.Length)], coinPos, Quaternion.identity);
            }
        }
    }
}
