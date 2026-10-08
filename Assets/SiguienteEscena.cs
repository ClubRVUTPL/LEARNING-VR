using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteEscena : MonoBehaviour
{
    //public string scenename;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);
    }
}
