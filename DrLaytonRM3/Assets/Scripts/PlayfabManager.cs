using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;


public class PlayfabManager : MonoBehaviour {
    //public static PlayfabManager instance;
    
    [Header("UI")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;

    public void RegisterButton() {
        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageText.text = "Registered and logged in";
    }

    public void LoginButton() {
    
    }

    public void ResetPasswordButton() {
    
    }


    void OnPasswordReset(SendAccountRecoveryEmailResult result) {

    }


    // Start is called before the first frame update
   void Start() {
        Login();
   }
   
    void Login() {
        
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result) {
        Debug.Log("Successful login/account create");
    }

    // Update is called once per frame
    void OnError(PlayFabError error)  {
        Debug.Log("Error while logging in/creating account");
        Debug.Log(error.GenerateErrorReport());
    }

   public void SendLeaderboard(int score){
        var request= new UpdatePlayerStatisticsRequest{
            Statistics= new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName="Score",
                    Value=score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,OnLeaderBoardUpdate,OnError);
    }

    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result){
        Debug.Log("Successfull leaderboard sent");
    }

    public void GetLeaderboard() {

        var request = new GetLeaderboardRequest {
            StatisticName = "experienceScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError);
    }


    void OnLeaderBoardGet(GetLeaderboardResult result) {
    
        foreach (var item in result.Leaderboard) {
            Debug.Log(item.Position + "" + item.PlayFabId + "" + item.StatValue);
        }
    }

}
