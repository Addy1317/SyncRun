using SyncRun.Audio;
using SyncRun.Service;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SyncRun.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Setting Panel")]
        [SerializeField] private GameObject settingPanel;
        [SerializeField] private Button settingsButton;

        [Header("Pause Panel")]
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button homeButton;
        [SerializeField] private Button quitButton;

        [Header("GameOver")]
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private Button gameOverRestartButton;
        [SerializeField] private Button gameOverHomeButton;
        [SerializeField] private Button gameOverQuitButton;

        #region Unity Methods
        private void OnEnable()
        {
            settingsButton.onClick.AddListener(OnSettingsButton);

            pauseButton.onClick.AddListener(OnPauseButton);
            resumeButton.onClick.AddListener(OnResumeButton);
            restartButton.onClick.AddListener(OnRestartButton);
            homeButton.onClick.AddListener(OnHomebutton);
            quitButton.onClick.AddListener(OnQuitButton);

            gameOverRestartButton.onClick.AddListener(OnGORestartButton);
            gameOverHomeButton.onClick.AddListener(OnGOHomeButton);
            gameOverQuitButton.onClick.AddListener(OnGOQuitbutton);
        }

        private void OnDisable()
        {
            settingsButton.onClick.RemoveListener(OnSettingsButton);

            pauseButton.onClick.RemoveListener(OnPauseButton);
            resumeButton.onClick.RemoveListener(OnResumeButton);
            restartButton.onClick.RemoveListener(OnRestartButton);
            homeButton.onClick.RemoveListener(OnHomebutton);
            quitButton.onClick.RemoveListener(OnQuitButton);

            gameOverRestartButton.onClick.RemoveListener(OnGORestartButton);
            gameOverHomeButton.onClick.RemoveListener(OnGOHomeButton);
            gameOverQuitButton.onClick.RemoveListener(OnGOQuitbutton);
        }

        private void Start()
        {
            GameServices.Instance.vfxManager.AddHoverEffect(settingsButton);
            
            GameServices.Instance.vfxManager.AddHoverEffect(pauseButton);

            GameServices.Instance.vfxManager.AddHoverEffect(resumeButton);
            GameServices.Instance.vfxManager.AddHoverEffect(restartButton);
            GameServices.Instance.vfxManager.AddHoverEffect(homeButton);
            GameServices.Instance.vfxManager.AddHoverEffect(quitButton);

            GameServices.Instance.vfxManager.AddHoverEffect(gameOverRestartButton);
            GameServices.Instance.vfxManager.AddHoverEffect(gameOverHomeButton);
            GameServices.Instance.vfxManager.AddHoverEffect(gameOverQuitButton);

        }

        #endregion

        #region Settings Panel Method

        private void OnSettingsButton()
        {
            settingPanel.SetActive(!settingPanel.activeSelf);
            GameServices.Instance.audioManager.PlaySFX(SFXType.ButtonClickSFX);
        }
        #endregion

        #region Pause Panel Method
        private void OnPauseButton()
        {
            pausePanel.SetActive(!pausePanel.activeSelf);
            GameServices.Instance.audioManager.PlaySFX(SFXType.ButtonClickSFX);
        }

        private void OnResumeButton()
        {
            pausePanel.SetActive(false);
            GameServices.Instance.audioManager.PlaySFX(SFXType.ButtonClickSFX);
        }

        private void OnRestartButton()
        {
            SceneManager.LoadScene("MainGame");
            GameServices.Instance.audioManager.PlaySFX(SFXType.ButtonClickSFX);
        }

        private void OnHomebutton()
        {
            SceneManager.LoadScene("MainMenu");
            GameServices.Instance.audioManager.PlaySFX(SFXType.ButtonClickSFX);
        }

        private void OnQuitButton()
        {
            Application.Quit();
            GameServices.Instance.audioManager.PlaySFX(SFXType.ButtonClickSFX);
        }
        #endregion

        #region GameOver Panel Method

        private void OnGORestartButton()
        {
            SceneManager.LoadScene("MainGame");
            GameServices.Instance.audioManager.PlaySFX(SFXType.ButtonClickSFX);
        }

        private void OnGOHomeButton()
        {
            SceneManager.LoadScene("MainGame");
            GameServices.Instance.audioManager.PlaySFX(SFXType.ButtonClickSFX);
        }

        private void OnGOQuitbutton()
        {
            Application.Quit();
            GameServices.Instance.audioManager.PlaySFX(SFXType.ButtonClickSFX);
        }

        #endregion
    }
}
