using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationHandler : MonoBehaviour
{
    [SerializeField] private Notification _notification;

    public void RefreshNotification(string text)
    {
        if (text != _notification.GetTextLabel)
        {
            _notification.canvasGroup.alpha = 1;
            _notification.SetTextLabel(text);
            StartCoroutine(Show());
        }
        else
            return;
    }

    IEnumerator Show()
    {
        yield return new WaitForSeconds(3f);
        _notification.canvasGroup.alpha = 0;
    }
}
