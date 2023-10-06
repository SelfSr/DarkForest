using System.Collections;
using UnityEngine;

public class ScreamOn6Location : MonoBehaviour
{
    [SerializeField] private AudioClip _spawnSound;
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private float _approachSpeed = 2f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _spawnHeightOffset = -2f;
    [SerializeField] private float _spawnDistance = 5f;

    private Camera mainCamera;
    private bool _isOnePlay = true;
    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_isOnePlay)
        {
            Vector3 cameraCenter = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, mainCamera.nearClipPlane));
            Vector3 spawnPosition = cameraCenter + mainCamera.transform.forward * _spawnDistance;
            spawnPosition.y += _spawnHeightOffset;
            Quaternion rotation = Quaternion.LookRotation(mainCamera.transform.forward);
            _isOnePlay = false;

            if (_objectToSpawn != null)
            {
                GameObject spawnedObject = Instantiate(_objectToSpawn, spawnPosition, rotation);
                if (_spawnSound != null)
                {
                    AudioSource audioSource = spawnedObject.AddComponent<AudioSource>();
                    audioSource.clip = _spawnSound;
                    audioSource.Play();
                }
                StartCoroutine(ApproachAndRotate(spawnedObject.transform));
            }
        }
    }
    private IEnumerator ApproachAndRotate(Transform objTransform)
    {
        while (Vector3.Distance(objTransform.position, mainCamera.transform.position) > 1.5f)
        {
            objTransform.position = Vector3.MoveTowards(objTransform.position, mainCamera.transform.position, _approachSpeed * Time.deltaTime);

            Vector3 directionToCamera = mainCamera.transform.position - objTransform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
            objTransform.rotation = Quaternion.Slerp(objTransform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            yield return null;
        }
        Destroy(objTransform.gameObject);
    }
}
