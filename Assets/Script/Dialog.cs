using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Dialog : MonoBehaviour
{
    Text dialogText;
    Button button;
    Text dialogButtonText;

    public string displayText
    {
        set
        {
            dialogText.text = value;
        }
        get
        {
            return dialogText.text;
        }
    }
    public string buttonText
    {
        set
        {
            if (value != null)
            {
                button.gameObject.SetActive(true);
                dialogButtonText.text = value;
            }
            else
            {
                button.gameObject.SetActive(false);
            }
        }
        get
        {
            return dialogButtonText.text;
        }
    }
    public UnityEngine.Events.UnityAction buttonAction
    {
        set
        {
            if (value != null)
            {
                button.onClick.AddListener(value);
            }
            else
            {
                button.onClick.RemoveAllListeners();
            }
        }
    }

    private void Awake()
    {
        Text[] textChildren = this.gameObject.GetComponentsInChildren<Text>();
        dialogText = textChildren.First(tr => tr.gameObject.name == "DialogText");
        if (dialogText == null)
        {
            Debug.LogError("Dialog is not found");
        }
        Button[] buttonChildren = this.gameObject.GetComponentsInChildren<Button>();
        if (buttonChildren.Length == 0)
        {
            Debug.LogError("Button is not found");
        }
        button = buttonChildren[0];
        dialogButtonText = button.gameObject.GetComponentInChildren<Text>();
        if (dialogButtonText == null)
        {
            Debug.LogError("ButtonText is not found");
        }
    }
    public void Open(string message, string buttonLabel = null, UnityEngine.Events.UnityAction action = null)
    {
        this.gameObject.SetActive(true);
        displayText = message;
        buttonText = buttonLabel;
        buttonAction = action;
    }

    public void Close()
    {
        button.onClick.RemoveAllListeners();
        this.gameObject.SetActive(false);
    }

}
