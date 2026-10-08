using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class DialogEventController : MonoBehaviour
{
    public UnityEvent onOption1Selected;
    public UnityEvent onOption2Selected;

    // Método para cambiar de escena
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Evento para la opción 1 seleccionada
    public void Option1Selected()
    {
        onOption1Selected.Invoke();
    }

    // Evento para la opción 2 seleccionada
    public void Option2Selected()
    {
        onOption2Selected.Invoke();
    }
}
