using UnityEngine;

public class duration_controller : MonoBehaviour
{
    public float durationIncreaseInterval = 30f; // 30초마다
    public float durationIncreaseAmount = 0.5f;  // 0.5씩 증가
    public ParticleSystem targetEffect;          // 변경할 이펙트 프리펩
    private float timer = 0f;
    private ParticleSystem.MainModule mainModule;

    void Start()
    {
        if (targetEffect != null)
            mainModule = targetEffect.main; // ✅ main 모듈 가져오기
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= durationIncreaseInterval)
        {
            timer = 0f;

            // ✅ duration 0.5씩 증가
            mainModule.duration += durationIncreaseAmount;

            Debug.Log("Duration 증가! 현재 값 : " + mainModule.duration);
        }
    }
}
