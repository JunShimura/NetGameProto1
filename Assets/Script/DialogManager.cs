using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private Dialog dialog;
    private InputDialog inputDialog;
    private GameObject currentDialog;
    enum OpenMode
    {
        none, Dialog, InputDialog
    }
    OpenMode _openMode = OpenMode.none;
    OpenMode openMode
    {
        set
        {
            if (_openMode != value && _openMode != OpenMode.none && currentDialog != null)
            {
                currentDialog.SetActive(false);
            }

            if (value == OpenMode.none)
            {
                currentDialog = null;
            }
            _openMode = value;
            switch (value)
            {
                case OpenMode.Dialog:
                    currentDialog = dialog.gameObject;
                    break;
                case OpenMode.InputDialog:
                    currentDialog = inputDialog.gameObject;
                    break;
                default:
                    currentDialog = null;
                    break;
            }
        }
        get
        {
            return _openMode;
        }
    }

    private void Awake()
    {
        dialog = this.gameObject.GetComponentInChildren<Dialog>();
        if (dialog == null)
        {
            Debug.LogError("Dialog is not found");
        }
        inputDialog = this.gameObject.GetComponentInChildren<InputDialog>();
        if (inputDialog == null)
        {
            Debug.LogError("InputDialog is not found");
        }

    }
    private void Start()
    {
        dialog.gameObject.SetActive(false);
        inputDialog.gameObject.SetActive(false);
    }
    public void DialogButton(string message, string buttonLabel = null, UnityEngine.Events.UnityAction action = null)
    {
        openMode = OpenMode.Dialog;
        dialog.gameObject.SetActive(true);
        dialog.Open(message, buttonLabel, action);
    }
    public void SetMessage(string message)
    {
        dialog.displayText = message;
    }
    public void InputDialog(string message, string buttonLabel = null, UnityEngine.Events.UnityAction action = null)
    {
        openMode = OpenMode.InputDialog;
        inputDialog.gameObject.SetActive(true);
        inputDialog.Open(message, buttonLabel, action);
    }
    public string GetInputValue()
    {
        return inputDialog.inputText;
    }


}
