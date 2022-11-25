using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NoteModel
{
    public NoteType MusicalNote;
    public KeyCode InputKey;
    public Color Color;
    public Lane NoteButton;
    public Text KeyDisplay;
    public int Score;
}
