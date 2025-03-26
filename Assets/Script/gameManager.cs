using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //싱글톤
    public UserData userData; //사용자 데이터

    public TextMeshProUGUI userNameText; //UI
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI cashText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //userData = new UserData("lolap", 100000, 50000); //초기 사용자 데이터
        LoadUserData(); // 저장된 데이터 로드 --10쳅터
        RefreshUI(); //UI 반영
    }

    public void RefreshUI() 
    {
        userNameText.text = userData.userName;
        balanceText.text = "Banlanc:      " + FormatMoney(userData.balance) + "원";
        cashText.text = "현금 \n" + FormatMoney(userData.cash) + "원";
        userData.balance.ToString("N0");
    }

    private string FormatMoney(int amount)
    {
        return string.Format(CultureInfo.InvariantCulture, "{0:N0}", amount);
    }

    public void SaveUserData()
    {
        PlayerPrefs.SetInt("Cash", userData.cash);
        PlayerPrefs.SetInt("Balance", userData.balance);
        PlayerPrefs.Save();
    }

    // 데이터 로드--10쳅터
    private void LoadUserData()
    {
        int cash = PlayerPrefs.GetInt("Cash", 100000);
        int balance = PlayerPrefs.GetInt("Balance", 50000);

        userData = new UserData("lolap", cash, balance);
    }
}



