using UnityEngine;
using System.IO;

public class LimpiarLeaderBoard : MonoBehaviour
{
    private string filePath; // Ruta del archivo JSON

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "sd.json");
    }

    public void LimpiarArchivo()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        
    }
}
