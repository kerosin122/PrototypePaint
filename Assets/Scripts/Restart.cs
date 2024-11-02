using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Restart : MonoBehaviour
{
   
    public Button restartButton;

    void Start()
    {
        
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartScene);
        }
        else
        {
            Debug.LogError("Кнопка не привязана");
        }
    }

    void RestartScene()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        
        SceneManager.LoadScene(currentScene.name);
    }
}