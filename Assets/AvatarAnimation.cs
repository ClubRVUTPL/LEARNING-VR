using UnityEngine;

public class AvatarAnimationController : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator del avatar
    public string animationTrigger = "PlayAnimation"; // Nombre del disparador de animación en el Animator

    private bool isPlayingAnimation = false;

    public void PlayAnimation()
    {
        if (!isPlayingAnimation)
        {
            // Activar el script y reproducir la animación
            isPlayingAnimation = true;
            animator.SetTrigger(animationTrigger);
        }
    }

    public void StopAnimation()
    {
        // Detener la animación y desactivar el script
        animator.ResetTrigger(animationTrigger);
        isPlayingAnimation = false;
    }
}
