using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject quad; // Asigna el quad desde el Inspector de Unity

    public void ShowQuad()
    {
        quad.SetActive(true);
    }
    public void DesactivateQuad()
    {
        quad.SetActive(false);
    }
}
