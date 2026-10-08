using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class SpaceManCharacter : MonoBehaviour
{
    public NPCConversation myConversation;
    public float delayBetweenDialogues = 1f; // Tiempo de espera entre diálogos

    private void Start()
    {
        // Iniciar automáticamente la conversación al iniciar la escena
        Invoke("StartConversationWithDelay", delayBetweenDialogues);
    }

    private void StartConversationWithDelay()
    {
        ConversationManager.Instance.StartConversation(myConversation);
    }
}