using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject quad;
    public Button playButton;

    void Start()
    {
        // Asigna la función de PlayVideo al evento de clic del botón
        playButton.onClick.AddListener(PlayVideo);
        videoPlayer.loopPointReached += EndReached;

        // Desactiva el quad al inicio
        quad.SetActive(false);
    }

    void PlayVideo()
    {
        // Activa el quad cuando se presiona el botón
        quad.SetActive(true);
        videoPlayer.Play();
        playButton.gameObject.SetActive(false);
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Desactiva el quad al finalizar el video
        quad.SetActive(false);
        playButton.gameObject.SetActive(false);
    }
}
