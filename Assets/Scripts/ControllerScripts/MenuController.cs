using SyncRun.Audio;
using SyncRun.Service;
using SyncRun.VFX;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SyncRun.Menu
{
    public class MenuController : MonoBehaviour
    {
        [Header("Main Menu buttons")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button quitButton;

        [Header("Settings Panel")]
        [SerializeField] private GameObject settingPanel;
        [SerializeField] private Button settingCloseButton;

        [Header("VFX/Audio Manager")]
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private VFXManager vfxManager;

        #region Unity Methods
        private void OnEnable()
        {
            startButton.onClick.AddListener(OnstartButton);
            settingsButton.onClick.AddListener(OnSettingsButton);
            quitButton.onClick.AddListener(OnQuitButton);  

            settingCloseButton.onClick.AddListener(OnSettingCloseButton); 
        }

        private void OnDisable()
        {
            startButton.onClick.RemoveListener(OnstartButton);
            settingsButton.onClick.RemoveListener(OnSettingsButton);
            quitButton.onClick.RemoveListener(OnQuitButton);

            settingCloseButton.onClick.RemoveListener(OnSettingCloseButton);
        }

        private void Start()
        {
            vfxManager.AddHoverEffect(startButton);
            vfxManager.AddHoverEffect(settingsButton);
            vfxManager.AddHoverEffect(quitButton);
            
            vfxManager.AddHoverEffect(settingCloseButton);
        }
        #endregion

        #region MainMenu Methods

        private void OnstartButton()
        {
            SceneManager.LoadScene("MainGame");
            audioManager.PlaySFX(SFXType.ButtonClickSFX);
        }

        private void OnSettingsButton()
        {
            settingPanel.SetActive(true);
            audioManager.PlaySFX(SFXType.ButtonClickSFX);
        }

        private void OnQuitButton()
        {
            Application.Quit();
            audioManager.PlaySFX(SFXType.ButtonClickSFX);
        }

        #endregion

        #region SettingsPanel Methods

        private void OnSettingCloseButton()
        {
            settingPanel.SetActive(false);
            audioManager.PlaySFX(SFXType.ButtonClickSFX);
        }
        #endregion
    }
}
