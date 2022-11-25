using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class GameTest
{
    private GameManager m_GameManager;
    private SoundManager m_SoundManger;
    private NoteSpawner m_NoteSpawner;
    private NoteManager m_NoteManager;
    private UIController m_UIGameManager;

    private bool IsAlready = false;
    private List<Lane> m_Lanes = new List<Lane>();
    private List<NoteModel> m_Notes = new List<NoteModel>();

    [SetUp]
    public void SetUp()
    {
        if (!IsAlready)
        {
            SetUpUIGameManger();
            SetUpSoundManager();
            SetupGameController();
            SetUpNoteSpawner();
            AddLaneAndNote();
            m_GameManager.gameObject.AddComponent<NoteManager>().SetTestData(m_Notes);
            IsAlready = true;
        }
    }

    private void AddLaneAndNote()
    {
        for (int i = 0; i < 4; i++)
        {
            KeyCode key = (KeyCode)(97 + i);
            Color color = Color.blue;
            AddLane(i, key, color);
            AddNote(i, key, color);
        }
    }

    private void AddNote(int i, KeyCode key, Color color)
    {
        NoteModel note = new NoteModel();
        note.Color = color;
        note.InputKey = key;
        GameObject textDisplay = new GameObject("TextDisplay");
        textDisplay.AddComponent<Text>();
        note.KeyDisplay = textDisplay.GetComponent<Text>();
        note.MusicalNote = (NoteType)Random.Range(1, 6);
        note.NoteButton = m_Lanes[i];
        note.Score = 20;
        m_Notes.Add(note);
    }

    private void AddLane(int i, KeyCode key, Color color)
    {
        GameObject lane = new GameObject($"Lane{i}");
        lane.AddComponent<Lane>();
        lane.GetComponent<Lane>().SetUp(key, color);
        lane.transform.position = new Vector3(0 + (i * 50), -150, 0);
        m_Lanes.Add(lane.GetComponent<Lane>());
    }

    private void SetupGameController()
    {
        GameObject gameManager = new GameObject("GameManager");
        gameManager.AddComponent<GameManager>().SetTestData("wrongPatch", m_SoundManger, m_UIGameManager);
        m_GameManager = gameManager.GetComponent<GameManager>();
    }

    private void SetUpSoundManager()
    {
        GameObject gameObject = new GameObject("SoundManger");
        gameObject.AddComponent<AudioSource>();
        gameObject.AddComponent<SoundManager>().SetTestData(Resources.Load("Sound/DrumTrack1") as AudioClip);
        m_SoundManger = gameObject.GetComponent<SoundManager>();
    }

    private void SetUpUIGameManger()
    {
        GameObject gameObject = new GameObject("UIManager");
        Text scoreTxt = new GameObject("ScoreText").AddComponent<Text>();
        Text gameOverTxt = new GameObject("GameoverText").AddComponent<Text>();
        gameObject.AddComponent<UIController>().SetTestData(scoreTxt, gameOverTxt);
        m_UIGameManager = gameObject.GetComponent<UIController>();
    }

    private void SetUpNoteSpawner()
    {
        GameObject spawnPos = new GameObject("SpawnPosition");
        spawnPos.transform.position = new Vector3(0, 150f, 0);
        m_GameManager.gameObject.AddComponent<NoteSpawner>().SetTestData(1f, 1f, Resources.Load("Prefabs/BaseNote") as GameObject, spawnPos.transform);
        m_NoteSpawner = m_GameManager.GetComponent<NoteSpawner>();
    }

    [UnityTest]
    public IEnumerator GetLaneList()
    {
        yield return null;
        Assert.AreNotEqual(m_Lanes.Count, 0);
    }

    [UnityTest]
    public IEnumerator GetNoteList()
    {
        yield return null;
        Assert.AreNotEqual(m_Notes.Count, 0);
    }

    [UnityTest]
    public IEnumerator NoteIsScroll()
    {
        GameObject note = GameObject.Instantiate(Resources.Load("Prefabs/BaseNote"), Vector3.zero, Quaternion.identity) as GameObject;
        note.name = "Note";
        NoteInitModel initData = new NoteInitModel();
        initData.Data = m_Notes[0];
        initData.DespawnPosition = m_Lanes[0].gameObject.transform.position;
        initData.LeadInTime = 0.3f;
        initData.NoteSize = 1f;
        initData.SpawnPosition = Vector3.zero;
        initData.SpawnTime = 0.5f;
        note.GetComponent<Note>().SetUp(initData);
        yield return new WaitForSeconds(3f);
        Assert.AreNotEqual(note.transform.position, Vector3.zero);
    }

    [UnityTest]
    public IEnumerator OnGetScore()
    {
        GameEventHelper.OnAddScore?.Invoke(200);
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(m_GameManager.Score, 200);
    }

    [UnityTest]
    public IEnumerator OnGameover()
    {
        GameEventHelper.OnGameOver?.Invoke();
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(m_GameManager.IsGameOver, true);
    }
}
