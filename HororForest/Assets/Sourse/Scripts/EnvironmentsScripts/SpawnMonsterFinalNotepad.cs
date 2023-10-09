using UnityEngine;

public class SpawnMonsterFinalNotepad : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private AudioSource _spawnAudio;
    [SerializeField] private GameObject[] _cutSceneObjectShow;
    [SerializeField] private GameObject[] _cutSceneObjectHide;

    private bool isOnePlayCutscene = true;
    private GameObject spawnedEnemy;

    private void Start()
    {
        Invoke("SpawnEnemy", 40);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = player.position - player.forward * 15f;
        spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        Animator enemyAnimator = spawnedEnemy.GetComponent<Animator>();
        if (enemyAnimator != null)
        {
            enemyAnimator.SetInteger("Situation", 1);
        }

        EnemyFollowPlayer enemyFollow = spawnedEnemy.AddComponent<EnemyFollowPlayer>();
        enemyFollow.target = player;
    }

    private void Update()
    {
        if (spawnedEnemy != null && Vector3.Distance(player.position, spawnedEnemy.transform.position) < 2f)
        {
            if (isOnePlayCutscene)
            {
                foreach (var obj in _cutSceneObjectShow)
                    obj.SetActive(true);
                foreach (var obj in _cutSceneObjectHide)
                {
                    spawnedEnemy.SetActive(false);
                    obj.SetActive(false);
                }
                isOnePlayCutscene = false;
            }
        }
    }
}
