using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthUI : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;

    public Button registerButton;

    public Text statusText;

    private authManager authManager;

    // Start is called before the first frame update
    void Start()
    {
        authManager = GetComponent<authManager>();
        registerButton.onClick.AddListener(OnregisterClick);
    }

    private void OnregisterClick()
    {
        StartCoroutine(RegisterCorouitine());
    }

    private IEnumerator RegisterCorouitine()
    {
        statusText.text = "ȸ������ ��...";
        yield return StartCoroutine(authManager.Register(usernameInput.text, passwordInput.text));
        statusText.text = "ȸ������ ����. �α��� ���ּ���";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
