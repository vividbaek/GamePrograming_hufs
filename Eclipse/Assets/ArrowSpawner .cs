using System.Collections;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [Header("떨어뜨릴 Arrow 프리팹")]
    public GameObject arrowPrefab;

    [Header("스폰 X 범위")]
    public float spawnXMin = -8f;
    public float spawnXMax = 8f;

    [Header("스폰 Y 위치")]
    public float spawnY = 6f;

    [Header("스폰 간격 (초), 랜덤 범위")]
    public float intervalMin = 0.5f;
    public float intervalMax = 1.5f;

    [Header("위 캐릭터 컨트롤러 (조작할 때만 스폰)")]
    public CharacterController2D upperCtrl;

    void Start()
    {
        if (arrowPrefab == null || upperCtrl == null)
            Debug.LogError("ArrowSpawner: arrowPrefab 과 upperCtrl 을 에디터에서 반드시 할당하세요!");

        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            // 1) 위 캐릭터가 조작 가능할 때만 스폰
            if (upperCtrl.canControl)
            {
                // 2) 랜덤 대기
                float wait = Random.Range(intervalMin, intervalMax);
                yield return new WaitForSeconds(wait);

                // 3) 랜덤 X, 고정 Y 위치에서 Instantiate
                float x = Random.Range(spawnXMin, spawnXMax);
                Vector3 pos = new Vector3(x, spawnY, 0f);
                Instantiate(arrowPrefab, pos, Quaternion.identity);
            }
            else
            {
                // 위 캐릭터가 비활성화 상태면 매 프레임 재확인
                yield return null;
            }
        }
    }
}
