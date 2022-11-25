public struct MIDIDataModel
{
    public NoteType MusicalNote;
    public float Time;
    public MIDIDataModel(float time, NoteType note)
    {
        Time = time;
        MusicalNote = note;
    }
}
