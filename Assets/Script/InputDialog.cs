using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class InputDialog : MonoBehaviour
{
    private Text _dialogText;
    private Text _inputText;
    private Button _button;
    Text dialogButtonText;

    public string displayText
    {
        set
        {
            _dialogText.text = value;
        }
        get
        {
            return _dialogText.text;
        }
    }
    public string inputText
    {
        get
        {
            return _inputText.text;
        }
    }
    public string buttonText
    {
        set
        {
            if (value != null)
            {
                _button.gameObject.SetActive(true);
                dialogButtonText.text = value;
            }
            else
            {
                _button.gameObject.SetActive(false);
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
                _button.onClick.AddListener(value);
            }
            else
            {
                _button.onClick.RemoveAllListeners();
            }
        }
    }
 

    private void Awake()
    {
        Text[] textChildren = this.gameObject.GetComponentsInChildren<Text>();
        _dialogText = textChildren.First(tr => tr.gameObject.name == "DialogText");
        if (_dialogText == null)
        {
            Debug.LogError("DialogText is not found");
        }
        _inputText = textChildren.First(tr => tr.gameObject.name == "InputText");
        if (_inputText == null)
        {
            Debug.LogError("InputText is not found");
        }
        Button[] buttonChildren = this.gameObject.GetComponentsInChildren<Button>();
        if (buttonChildren.Length == 0)
        {
            Debug.LogError("Button is not found");
        }
        _button = buttonChildren[0];
        dialogButtonText = _button.gameObject.GetComponentInChildren<Text>();
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
        _button.onClick.RemoveAllListeners();
        this.gameObject.SetActive(false);
    }
}
