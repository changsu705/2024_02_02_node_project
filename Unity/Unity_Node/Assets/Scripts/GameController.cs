using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameView gameView;
    private PlayerModel playerModel;
    private GameAPI gameAPI;

    void Start()
    {
        gameAPI = gameObject.AddComponent<GameAPI>();
        gameView.SetRegistarButtonListener(OnRegisterButtonClicked);
        gameView.SetLoginButtonListener(OnLoginButtonClicked);
        gameView.SetCollectButtonListener(OnCollexctButtonClicked);
    }

    public void OnRegisterButtonClicked()
    {
        string playerName = gameView.playerNameInput.text;
        StartCoroutine(gameAPI.RegisterPlayer(playerName, "1234"));
    }

    public void OnLoginButtonClicked()
    {
        string playerName = gameView.playerNameInput.text;
        //StartCoroutine(gameAPI.RegisterPlayer(playerName, "1234"));
    }

    public void OnCollexctButtonClicked()
    {
        if(playerModel == null)
        {
            Debug.Log($"Collecting resources for : {playerModel.PlayerName}");
            StartCoroutine(CollectCoroutine(playerModel.playerName));
        }
        else
        {
            Debug.LogError("Player model is null");
        }
    }

    private IEnumerator CollectCoroutine(string playerName)    
    {
        yield return gameAPI.CollectResources(playerName, flag =>
        {
            UpdateResourcesDisplay();
        });
    }

    private IEnumerator LoginPlayerCoroutine(string playerName, string password)
    {
        yield return gameAPI.LoginPlayer(playerName, password, player =>
        {
            playerModel = player;
            UpdateResourcesDisplay();
        });
    }

    private void UpdateResourcesDisplay()
    {
        if(playerModel != null)
        {
            gameView.UpdateResources(playerModel.metal, playerModel.crystal, playerModel.deuterium);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
