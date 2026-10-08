using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class NodeWithDelay : MonoBehaviour
{
    // Variable para configurar el tiempo de espera para este nodo (en segundos).
    public float delayTime = 5f;

    // UnityEvent que se activará cuando finalice el tiempo de espera.
    public UnityEvent onDelayFinished;

    // Método que se ejecutará cuando se active el evento del nodo.
    public void OnNodeEventTrigger()
    {
        StartCoroutine(DelayCoroutine());
    }

    // Corutina que manejará el tiempo de espera antes de activar el UnityEvent.
    private IEnumerator DelayCoroutine()
    {
        // Esperar el tiempo de espera especificado antes de activar el evento.
        yield return new WaitForSeconds(delayTime);

        // Activar el evento cuando finalice el tiempo de espera.
        onDelayFinished?.Invoke();
    }
}
