using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleIntro : MonoBehaviour
{
    public enum BattleState
    {
        Intro,
        ActionSelect,
        MoveSelect,
        Busy
    }

    [Header("Pokemon UI")]
    public RectTransform playerPokemon;
    public RectTransform enemyPokemon;

    [Header("UI")]
    public GameObject enemyHud;
    public GameObject playerHud;
    public GameObject commandBox;

    [Header("Positions")]
    public Vector2 playerStartPos;
    public Vector2 playerEndPos;
    public Vector2 enemyStartPos;
    public Vector2 enemyEndPos;

    [Header("Timing")]
    public float slideDuration = 0.45f;
    public float enemyDelay = 0.25f;

    private void Start()
    {
        StartCoroutine(PlayIntro());
    }

    public BattleState state;

    IEnumerator PlayIntro()
    {
        // 처음에는 HUD/커맨드 숨김
        enemyHud.SetActive(false);
        playerHud.SetActive(false);
        commandBox.SetActive(false);

        // 시작 위치로 배치
        playerPokemon.anchoredPosition = playerStartPos;
        enemyPokemon.anchoredPosition = enemyStartPos;

        // 플레이어 포켓몬 먼저 등장
        yield return StartCoroutine(SlideWithOvershoot(playerPokemon, playerStartPos, playerEndPos, slideDuration, true));

        yield return new WaitForSeconds(0.15f);

        // 적 포켓몬 등장
        yield return StartCoroutine(SlideWithOvershoot(enemyPokemon, enemyStartPos, enemyEndPos, slideDuration, false));

        yield return new WaitForSeconds(enemyDelay);

        // HUD 표시
        enemyHud.SetActive(true);
        playerHud.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        // 텍스트나 커맨드 박스 표시
        commandBox.SetActive(true);
    }

    IEnumerator SlideWithOvershoot(RectTransform target, Vector2 start, Vector2 end, float duration, bool fromLeft)
    {
        float time = 0f;

        // 살짝 지나치는 위치
        Vector2 overshoot = end + new Vector2(fromLeft ? 20f : -20f, 0f);

        // 1단계: 빠르게 들어오기
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            t = EaseOutCubic(t);
            target.anchoredPosition = Vector2.Lerp(start, overshoot, t);
            yield return null;
        }

        // 2단계: 원위치로 살짝 복귀
        float bounceTime = 0f;
        float bounceDuration = 0.12f;

        while (bounceTime < bounceDuration)
        {
            bounceTime += Time.deltaTime;
            float t = bounceTime / bounceDuration;
            t = EaseOutCubic(t);
            target.anchoredPosition = Vector2.Lerp(overshoot, end, t);
            yield return null;
        }

        target.anchoredPosition = end;
    }

    float EaseOutCubic(float t)
    {
        return 1f - Mathf.Pow(1f - t, 3f);
    }
}