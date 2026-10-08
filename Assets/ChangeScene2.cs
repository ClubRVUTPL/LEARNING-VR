using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string nombreEscena; // Nombre de la escena a la que se desea cambiar

    public void CambiarEscenaOnClick()
    {
        SceneManager.LoadScene(nombreEscena); // Carga la escena con el nombre especificado
    }
}
