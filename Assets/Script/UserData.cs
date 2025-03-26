using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class UserData : MonoBehaviour
{
    public string userName; //이름
    public int cash;         //소지현금
    public int balance;      //계좌잔액
    //TextMeshProUGUI;
    public UserData(string name, int cash, int balance)
    {
        this.userName = name;
        this.cash = cash;
        this.balance = balance;
    }

}
