using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupBank : MonoBehaviour
{
    public GameObject depositPanel; // 입금 UI 패널
    public GameObject withdrawPanel; // 출금 UI 패널
    public TMP_InputField depositInputField; // 입금 금액 입력 필드
    public TMP_InputField withdrawInputField; // 출금 금액 입력 필드
    public PopupError popupError; // 오류 팝업
    public Button[] depositButtons; // 빠른 입금 버튼들
    public Button[] withdrawButtons; // 빠른 출금 버튼들

    private void Start()
    {
        // 빠른 입금 버튼에 이벤트 추가
        foreach (Button button in depositButtons)
        {
            int amount = int.Parse(button.GetComponentInChildren<TextMeshProUGUI>().text.Replace("원", "").Trim());
            button.onClick.AddListener(() => Deposit(amount));
        }

        // 빠른 출금 버튼에 이벤트 추가
        foreach (Button button in withdrawButtons)
        {
            int amount = int.Parse(button.GetComponentInChildren<TextMeshProUGUI>().text.Replace("원", "").Trim());
            button.onClick.AddListener(() => Withdraw(amount));
        }
    }

    // 입금 기능
    public void Deposit(int amount)
    {
        UserData user = GameManager.Instance.userData;

        if (user.cash < amount)
        {
            popupError.Show("현금이 부족합니다!");
            return;
        }

        user.cash -= amount;
        user.balance += amount;
        GameManager.Instance.SaveUserData(); //입금 후 자동 저장--10쳅터
        GameManager.Instance.RefreshUI();
    }

    // 출금 기능
    public void Withdraw(int amount)
    {
        UserData user = GameManager.Instance.userData;

        if (user.balance < amount)
        {
            popupError.Show("잔액이 부족합니다!");
            return;
        }

        user.cash += amount;
        user.balance -= amount;
        GameManager.Instance.SaveUserData(); //입금 후 자동 저장--10쳅터
        GameManager.Instance.RefreshUI();
    }

    // 직접 입력하여 입금
    public void DepositFromInput()
    {
        if (int.TryParse(depositInputField.text, out int amount) && amount > 0)
        {
            Deposit(amount);
        }
        else
        {
            popupError.Show("유효한 금액을 입력하세요!");
        }
    }

    // 직접 입력하여 출금
    public void WithdrawFromInput()
    {
        if (int.TryParse(withdrawInputField.text, out int amount) && amount > 0)
        {
            Withdraw(amount);
        }
        else
        {
            popupError.Show("유효한 금액을 입력하세요!");
        }
    }

    // 입금 UI 활성화
    public void OpenDepositPanel()
    {
        depositPanel.SetActive(true);
        withdrawPanel.SetActive(false);
    }

    // 출금 UI 활성화
    public void OpenWithdrawPanel()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(true);
    }

    // 모든 패널 닫기
    public void CloseAllPanels()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
    }

    // 뒤로가기 버튼
    public void BackToMainPanel()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
    }
}
