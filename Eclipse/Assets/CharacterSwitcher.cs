using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public CharacterController2D lowerCtrl;  // 아래 캐릭터 스크립트
    public CharacterController2D upperCtrl;  // 위 캐릭터 스크립트

    void Start()
    {
        lowerCtrl.canControl = true;
        upperCtrl.canControl = false;
    }

    // 버튼 OnClick 함수로 연결
    public void ToggleCharacter()
    {
        bool now = lowerCtrl.canControl;
        lowerCtrl.canControl = !now;
        upperCtrl.canControl = now;
    }
}
