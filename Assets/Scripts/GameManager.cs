using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string m_PathMIDI = null;
    [SerializeField] private SoundManager m_SoundManager = null;
    [SerializeField] private UIController m_UIGameManager = null;

    private NoteManager m_NoteManager;
    private NoteSpawner m_NoteSpawner;
    private MIDIFileConvert m_MIDIFileConvert;

    private int m_Score = 0;
    private bool m_IsGameOver;

    private void Start()
    {
        if (null != m_PathMIDI && null != m_SoundManager)
        {
            m_MIDIFileConvert = new MIDIFileConvert();
            m_NoteManager = GetComponent<NoteManager>();
            m_NoteSpawner = GetComponent<NoteSpawner>();
            Prepare();
        }
    }

    private void Prepare()
    {
        m_MIDIFileConvert.ConvertToData(m_PathMIDI);
        m_NoteManager.Setup();
        m_NoteSpawner.Setup(m_MIDIFileConvert.NoteList, m_NoteManager.Notes);
        m_SoundManager.SetUp(m_NoteSpawner.NoteSpeed);
        GameEventHelper.OnGameStart?.Invoke();
    }

    private void Update()
    {
        m_NoteSpawner.SpawnNote(m_SoundManager.GetSongPosition());
        if (m_IsGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.GetActiveScene();
                SceneManager.LoadScene("RhythmGamePlay");
            }
        }
    }

    private void OnEnable()
    {
        GameEventHelper.OnAddScore += AddScore;
        GameEventHelper.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        GameEventHelper.OnAddScore -= AddScore;
        GameEventHelper.OnGameOver -= GameOver;
    }
    private void GameOver()
    {
        m_IsGameOver = true;
        if (null != m_UIGameManager)
            m_UIGameManager.ShowGameOver();
    }

    private void AddScore(int score)
    {
        m_Score += score;
        if (null != m_UIGameManager)
            m_UIGameManager.SetScore(m_Score);
    }

#if UNITY_EDITOR
    public int Score => m_Score;
    public bool IsGameOver => m_IsGameOver;
    public void SetTestData(string path, SoundManager soundManager, UIController uiGameManager)
    {
        m_PathMIDI = path;
        m_SoundManager = soundManager;
        m_UIGameManager = uiGameManager;
    }
#endif

}
