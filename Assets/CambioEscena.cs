using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;

/*
    jojobro:  
    este script sirve para cambiar de escena cuando tocas un objeto VR con tu XR Ray Interactor / Direct Interactor.
    aqui usamos OnSelectEntered(SelectEnterEventArgs) porque Unity elimino el metodo anterior.
*/

public class ChangeSceneOnClickXR : XRBaseInteractable
{
    public string sceneName; // nombre de la escena que queremos cargar

    // nuevo metodo valido
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // cambia de escena
        SceneManager.LoadScene(sceneName);
    }
}
