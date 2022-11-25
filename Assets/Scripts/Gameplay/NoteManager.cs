using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField]private List<NoteModel> m_Notes = new List<NoteModel>();
    public List<NoteModel> Notes => m_Notes;
    public void Setup()
    {
        foreach (var note in m_Notes)
        {
            note.NoteButton.SetUp(note.InputKey, note.Color);
            note.KeyDisplay.text = note.InputKey.ToString();
        }
    }

#if UNITY_EDITOR
    public void SetTestData(List<NoteModel> notes)
    {
        m_Notes = notes;
    }
#endif
}
