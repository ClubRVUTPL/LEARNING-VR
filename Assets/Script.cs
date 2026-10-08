using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using TMPro;

public class Script : MonoBehaviour
{
    bool triggerResultEmail = false;
    bool resultEmailSuccess;

    public TMP_InputField To;
    public TMP_InputField Body;
    public TMP_InputField AttachFile;
    public QuizManager quizManager;

    public GameObject leaderboardPanel;

    public void sendEmail()
    {
        int score = quizManager.score;

        SimpleEmailSender.emailSettings.STMPClient = "smtp.outlook.com";
        SimpleEmailSender.emailSettings.SMTPPort = 587;
        SimpleEmailSender.emailSettings.UserName = "ergaibor@utpl.edu.ec";
        SimpleEmailSender.emailSettings.UserPass = "";

        string emailBody = "Tu calificación dentro del laboratorio de inglés LearningVR ha sido de: " + score.ToString();

        SimpleEmailSender.Send(To.text, "LearningVR", emailBody, AttachFile.text, SendCompleteCallBack);
    }

    private void SendCompleteCallBack(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Cancelled || e.Error != null)
        {
            print("Email no enviado: " + e.Error.ToString());
            resultEmailSuccess = false;
            triggerResultEmail = true;
        }
        else
        {
            print("Email enviado correctamente");
            resultEmailSuccess = true;
            triggerResultEmail = true;

            quizManager.GoPanel.SetActive(false);

            leaderboardPanel.SetActive(true);
        }
    }
}
