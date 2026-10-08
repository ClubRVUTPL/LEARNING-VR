using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button buttonToShow; // Asigna el botón en el Inspector

    void Start()
    {
        // Encuentra el objeto con el script QuizManager
        QuizManager quizManager = FindObjectOfType<QuizManager>();

        // Verifica si el score es menor a 7
        if (quizManager.score < 7)
        {
            // Activa el botón si el score es menor a 7
            buttonToShow.gameObject.SetActive(true);
        }
        else
        {
            // Desactiva el botón si el score es 7 o mayor
            buttonToShow.gameObject.SetActive(false);
        }
    }
}
