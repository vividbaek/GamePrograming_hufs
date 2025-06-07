using UnityEngine;

public class FlagUpController : MonoBehaviour
{
    [Header("통과 허용할 벽 오브젝트")]
    public GameObject whiteWall;  // Hierarchy에서 white wall 오브젝트 할당

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // whiteWall GameObject 자체를 꺼서 보이지 않게 합니다.
            whiteWall.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 트리거 영역을 벗어나면 다시 활성화
            whiteWall.SetActive(true);
        }
    }
}
