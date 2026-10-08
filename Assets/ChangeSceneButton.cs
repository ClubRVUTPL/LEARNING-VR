using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeSceneButton : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a la que deseas cambiar

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

