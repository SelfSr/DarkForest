using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public Transform target;
    [SerializeField] private SpawnMonsterFinalNotepad spawnMonsterFinalNotepad;

    private bool isOnePlayCutscene = true;

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = lookRotation;
        }
    }
}
