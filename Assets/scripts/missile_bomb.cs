using UnityEngine;

public class missile_bomb : MonoBehaviour
{
    [Header("Effect Prefabs (추천)")]
    public GameObject effectBombPrefab;      // 폭발 이펙트 프리팹
    public GameObject destroyedBombPrefab;   // 베기 효과 프리팹

    [Header("Settings")]
    public float effectExtraLife = 0.1f; // 파티클 끝난 뒤 여유로 둘 시간

    void Start()
    {
        transform.rotation = Quaternion.Euler(180f, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnEffect(effectBombPrefab);
            Destroy(gameObject,0.1f); // 미사일은 즉시 제거(혹은 0.01f)
        }
        else if (other.CompareTag("katana"))
        {
            SpawnEffect(destroyedBombPrefab);
            Destroy(gameObject);
        }
    }

    void SpawnEffect(GameObject prefab)
    {
        if (prefab == null) return;
        GameObject ef = Instantiate(prefab, transform.position, Quaternion.identity);

        // 파티클이 있다면 재생 후 수명 계산해서 자동 삭제
        ParticleSystem ps = ef.GetComponentInChildren<ParticleSystem>();
        if (ps != null)
        {
            // 안전하게 Stop 후 Play (프리팹에 Play On Awake 켜져 있어도 괜찮음)
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            ps.Play();

            // 대략적인 수명 계산: duration + startLifetime (최대값 사용)
            var main = ps.main;
            float life = main.duration;
            // startLifetime은 MinMaxCurve — constantMax 사용 (유형에 따라 다름)
            try
            {
                life += main.startLifetime.constantMax;
            }
            catch
            {
                life += 1f;
            }
            Destroy(ef, life + effectExtraLife);
        }
        else
        {
            // 파티클이 없으면 안전하게 2초 뒤 삭제
            Destroy(ef, 2f);
        }
    }
}
