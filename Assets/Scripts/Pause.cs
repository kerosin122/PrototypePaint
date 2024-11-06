using UnityEngine.UI;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private Text buttonText;
    public Button pauseButton;
    private bool isPaused = false;

    void Start()
    {
        // Убедитесь, что кнопка назначена
        if (pauseButton != null)
        {
            buttonText = pauseButton.GetComponentInChildren<Text>();
            if (buttonText == null)
            {
                Debug.LogError("нет привязанного текста к кнопке.");
                return;
            }

            pauseButton.onClick.AddListener(TogglePause);
            UpdateButtonText();
        }
        else
        {
            Debug.LogError("кнопка не привязанна.");
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            // Снимаем игру с паузы
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            // Ставим игру на паузу
            Time.timeScale = 0f;
            isPaused = true;
        }

        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        if (isPaused)
        {
            buttonText.text = "Продолжить";
        }
        else
        {
            buttonText.text = "Пауза";
        }
    }
}