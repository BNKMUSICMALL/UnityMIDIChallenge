using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public float NoteSpeed = 1f;

    [SerializeField] private float m_NoteSize = 1f;
    [SerializeField] private GameObject m_NotePrefab = null;
    [SerializeField] private Transform m_NoteSpawnParent = null;


    private List<NoteInitModel> m_SpawnList = new List<NoteInitModel>();
    private int m_IndexOfNextNote = 0;
    private float m_NoteLeadInTime = 1f;
    private float m_NoteSpawnOffset = 0.2f;
    private bool IsSpawning = true;

    private void OnEnable()
    {
        GameEventHelper.OnGameStart += StartSpawnNote;
    }

    private void OnDisable()
    {
        GameEventHelper.OnGameStart -= StartSpawnNote;
    }

    public void Setup(List<MIDIDataModel> midiListData, List<NoteModel> noteListData)
    {
        m_SpawnList.Clear();
        foreach (MIDIDataModel midi in midiListData)
        {
            foreach (NoteModel noteData in noteListData)
            {
                if (midi.MusicalNote == noteData.MusicalNote)
                {
                    NoteInitModel initNote = new NoteInitModel();
                    initNote.Data = noteData;
                    initNote.NoteSize = m_NoteSize;
                    initNote.SpawnTime = midi.Time;
                    initNote.LeadInTime = (m_NoteLeadInTime / NoteSpeed);
                    initNote.DespawnPosition = noteData.NoteButton.gameObject.transform.position;
                    initNote.SpawnPosition = new Vector3(initNote.DespawnPosition.x, m_NoteSpawnParent.transform.position.y, initNote.DespawnPosition.z);
                    m_SpawnList.Add(initNote);
                }
            }
        }
    }

    public void SpawnNote(float songPos)
    {
        if (IsSpawning)
        {
            if (m_SpawnList.Count > m_IndexOfNextNote)
            {
                NoteInitModel initData = m_SpawnList[m_IndexOfNextNote];
                if (songPos >= initData.SpawnTime - (m_NoteSpawnOffset / NoteSpeed))
                {
                    GameObject note = Instantiate(m_NotePrefab, initData.SpawnPosition, Quaternion.identity, m_NoteSpawnParent);
                    note.GetComponent<Note>().SetUp(initData);
                    m_IndexOfNextNote++;
                }
            }
            else
            {
                if (null == FindObjectOfType<Note>())
                    IsGameOver();
            }
        }
    }

    private void StartSpawnNote()
    {
        IsSpawning = true;
    }

    private void IsGameOver()
    {
        IsSpawning = false;
        GameEventHelper.OnGameOver?.Invoke();
    }

#if UNITY_EDITOR
    public void SetTestData(float noteSpeed, float noteSize, GameObject notePrefab,Transform spawnPos)
    {
        NoteSpeed = noteSpeed;
        m_NoteSize = noteSize;
        m_NotePrefab = notePrefab;
        m_NoteSpawnParent = spawnPos;
    }
#endif
}
