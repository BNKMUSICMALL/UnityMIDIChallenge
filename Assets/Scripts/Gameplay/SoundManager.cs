using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip m_MIDISong;

    private AudioSource m_AudioSource;
    private float m_SongPosition;
    private float m_DPSTimeSong;
    private float m_PrepareTime = 0.7f;

    public void SetUp(float noteSpeed)
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_DPSTimeSong = (float)AudioSettings.dspTime;
        m_AudioSource.clip = m_MIDISong;
        m_PrepareTime = m_PrepareTime / noteSpeed;
        StartCoroutine("PrepareForStart");
    }
    private void Update()
    {
        m_SongPosition = (float)(AudioSettings.dspTime - m_DPSTimeSong);
    }

    public float GetSongPosition()
    {
        return m_SongPosition;
    }

    private IEnumerator PrepareForStart()
    {
        yield return new WaitForSeconds(m_PrepareTime);
        m_AudioSource.Play();
    }

#if UNITY_EDITOR
    public void SetTestData(AudioClip sound)
    {
        m_MIDISong = sound;
    }
#endif

}
