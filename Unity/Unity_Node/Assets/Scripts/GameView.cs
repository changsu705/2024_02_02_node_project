using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{

    //UI ¿ä¼Ò tjsdjs
    public Text playerNametext;
    public Text metalText;
    public Text crystalText;
    public Text deuteriumText;
    public InputField playerNameInput;

    public Button registerButton;
    public Button loginButton;
    public Button collectButton;
    public Button developButton;
    public Slider progressBar;

    public void SetPlayerName(string name)
    {
        playerNametext.text = name;
    }

    public void UpdateResources(int matal, int crystal, int deuterium)
    {
        metalText.text = $"Metal: {metalText}";
        crystalText.text = $"crystal:{crystalText}";
        deuteriumText.text = $"deuterium{deuteriumText}";
    }

    public void UpdateProgressBar(float value)
    {
        progressBar.value = value;
    }

    public void SetRegistarButtonListener(UnityEngine.Events.UnityAction action)
    {
        registerButton.onClick.RemoveAllListeners();
        registerButton.onClick.AddListener(action);
    }

    public void SetLoginButtonListener(UnityEngine.Events.UnityAction action)
    {
        registerButton.onClick.RemoveAllListeners();
        registerButton.onClick.AddListener(action);
    }
    public void SetCollectButtonListener(UnityEngine.Events.UnityAction action)
    {
        registerButton.onClick.RemoveAllListeners();
        registerButton.onClick.AddListener(action);
    }
    public void SetDevelopButtonListener(UnityEngine.Events.UnityAction action)
    {
        registerButton.onClick.RemoveAllListeners();
        registerButton.onClick.AddListener(action);
    }
    void Update()
    {
        
    }
}
