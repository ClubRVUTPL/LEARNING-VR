using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    public GameObject canvasToHide;  // Referencia al Canvas a ocultar
    public GameObject canvasToShow;  // Referencia al Canvas a mostrar

    public void OnButtonClick()
    {
        canvasToHide.SetActive(false);  // Oculta el Canvas
        canvasToShow.SetActive(true);   // Muestra el Canvas
    }
}
