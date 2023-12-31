using System;
using TMPro;
using UnityEngine;

public class MessegeManager : MonoBehaviour
{
    private bool isPanelOpened = false;
    private int _pageIndex;
    private int _lastPage;
    [SerializeField] private GameObject[] _textMesseges;
    [SerializeField] private TextMeshProUGUI _pageNumber;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _lastPage = Convert.ToInt32(_pageNumber.text);
    }

    private void FixedUpdate()
    {
        if (isPanelOpened)
        {
            int newPageIndex = Convert.ToInt32(_pageNumber.text);
            if (newPageIndex != _pageIndex)
            {
                if (newPageIndex >= 1 && newPageIndex <= _textMesseges.Length)
                {
                    _textMesseges[_lastPage - 1].SetActive(false);
                    _textMesseges[newPageIndex - 1].SetActive(true);
                    _lastPage = newPageIndex;
                    _pageIndex = newPageIndex;
                }
            }
        }
    }
    public void ToggleSwitchPage(bool enableSwitch)
    {
        isPanelOpened = enableSwitch;
    }

    public void SwitchNextPage()
    {
        if (Convert.ToInt32(_pageNumber.text) < PickupNotebook.numberNotebook)
        {
            SwitchPages(1);
        }
    }
    public void SwitchPreviousPage()
    {
        if (Convert.ToInt32(_pageNumber.text) > 1)
        {
            SwitchPages(-1);
        }
    }

    public void SwitchNextPageLesnikBook()
    {
        if (Convert.ToInt32(_pageNumber.text) < PickUpLesnikBook._numberLesnikBook)
        {
            SwitchPages(1);
        }
    }

    public void SwitchPreviousPageLesnikBook()
    {
        if (Convert.ToInt32(_pageNumber.text) > 1)
        {
            SwitchPages(-1);
        }
    }

    private void SwitchPages(int multiply)
    {
        string currentPageText = _pageNumber.text;
        int currentPage = Convert.ToInt32(currentPageText);
        int nextPage = currentPage + multiply;
        string nextPageText = nextPage.ToString();
        _pageNumber.text = nextPageText;
        _audioSource.Play();
    }
}

