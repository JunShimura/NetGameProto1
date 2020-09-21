using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    Dialog dialog;
    private void Awake()
    {
        dialog = this.gameObject.GetComponentInChildren<Dialog>();
        if (dialog == null)
        {
            Debug.LogError("Dialog is not found");
        }

    }
    private void Start()
    {
        //dialog.gameObject.SetActive(false);
    }
    public void MessagaButton(string message,string buttonLabel= null, UnityEngine.Events.UnityAction action = null)
    {
        dialog.gameObject.SetActive(true);
        dialog.Open(message, buttonLabel, action);
    }
    public void SetMessage(string message)
    {
        dialog.displayText = message;
    }

}
