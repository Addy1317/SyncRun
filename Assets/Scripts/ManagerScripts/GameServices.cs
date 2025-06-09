using SyncRun.Audio;
using SyncRun.Currency;
using SyncRun.Event;
using SyncRun.Generic;
using SyncRun.Spawn;
using SyncRun.UI;
using SyncRun.VFX;
using SyncRun.Manager;
using System.Collections.Generic;
using UnityEngine;

namespace SyncRun.Service
{
    public class GameServices : GenericMonoSingleton<GameServices>
    {
        [Header("Service")]
        [SerializeField] internal GameManager gameManager;
        [SerializeField] internal DataSyncManager dataSyncManager;
        [SerializeField] internal AudioManager audioManager;
        [SerializeField] internal CurrencyManager currencyManager;
        [SerializeField] internal SpawnManager enemySpawnManager;
        [SerializeField] internal UIManager uiManager;
        [SerializeField] internal VFXManager vfxManager;
        [SerializeField] internal EventManager eventManager;

        protected override void Awake()
        {
            base.Awake();
            if (Instance == this)
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            InitializeServices();
        }

        private void InitializeServices()
        {
            var services = new Dictionary<string, Object>
            {
            { "GameManager", gameManager },
            {"DataSyncManager", dataSyncManager },
            { "AudioManager", audioManager },
            { "CurrencyManager", currencyManager },
            { "EnemySpawnManager", enemySpawnManager },
            { "UIManager", uiManager },
            { "VFXManager", vfxManager },
            { "EventManager", eventManager }
            };

            foreach (var service in services)
            {
                if (service.Value == null)
                {
                    Debug.LogError($"{service.Key} failed to initialize.");
                }
                else
                {
                    Debug.Log($"{service.Key} is initialized.");
                }
            }
        }
    }
}
