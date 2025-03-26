using UnityEngine;
using TMPro;

public class PopupError : MonoBehaviour
{
    public GameObject popupPanel; // 오류 팝업 패널
    public TextMeshProUGUI errorMessage; // 오류 메시지 표시 텍스트

    // 오류 메시지를 설정하고 팝업을 띄우는 메서드
    public void Show(string message)
    {
        errorMessage.text = message;
        popupPanel.SetActive(true);
    }

    // 확인 버튼 클릭 시 팝업 닫기
    public void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
}
