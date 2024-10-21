using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.Networking;
using Newtonsoft;
using Newtonsoft.Json;

public class AuthManager : MonoBehaviour
{

    //서버 URL 및 PlayerPrefs 키 상수 정의
    private const string SERVER_URL = "http://localhost:4000";
    private const string ACCESS_TOKEN_RREFS_KEY = "AccessToken";
    private const string REFRESH_TOKEN_PREFS_KEY = "RefreshToken";
    private const string TOKEN_EXPITY_PREFS_KEY = "TOEKNExpiry";

    private string accessToekn;
    private string refreshToken;
    private DateTime tokenExpiryTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LoadTokenFromPrefs()
    {
        accessToekn = PlayerPrefs.GetString(ACCESS_TOKEN_RREFS_KEY, "");
        refreshToken = PlayerPrefs.GetString(REFRESH_TOKEN_PREFS_KEY, "");
        long expiryTicks = Convert.ToInt64(PlayerPrefs.GetString(TOKEN_EXPITY_PREFS_KEY));
    }


    public class LoginRespinse
    {
        public string accessToken;
        public string refreshToken;
    }

    //토큰 갱신 응답 데이터 구조
    [System.Serializable]
    public class RefreshTokenResponse
    {
        public string accessToekn;
    }

    public IEnumerator Register(string username, string password)
    {
        var user = new { username, password };
        var jsonData = JsonConvert.SerializeObject(user);

        using (UnityWebRequest www = UnityWebRequest.PostWwwForm($"{SERVER_URL}/reguster", "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Registration Error:{www.error}");
            }
            else
            {
                Debug.Log("Registration syccessful");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
