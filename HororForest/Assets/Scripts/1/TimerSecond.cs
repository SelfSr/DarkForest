using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimerSecond : MonoBehaviour
{
    private int sec = 0;
    private int min = 15;
    [SerializeField] private int delta = 0;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject firstText;

    void Start()
    {
        StartCoroutine(ITimer());
    }

    private void Update()
    {
        if (sec == 0 && min == 0)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (sec == 55)
        {
            firstText.SetActive(false);
        }
    }
    IEnumerator ITimer()
    {
        while (true)
        {
            if (sec == 0)
            {
                min--;
                sec = 60;
            }
            sec = sec - delta;
            text.text = min.ToString("D2") + ":" + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
}
