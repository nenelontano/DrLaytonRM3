using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour {
    
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

   /* public void SendLeaderboard(int score){
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
    }*/
}
