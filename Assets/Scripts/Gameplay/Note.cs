using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour, INote, IMover
{
    private NoteInitModel m_NoteInitData;
    private SpriteRenderer m_SR;
    private float m_Time = 0f;
    private bool m_CanBePressed;

    public void SetUp(NoteInitModel data)
    {
        m_NoteInitData = data;
        Initialize();
    }

    private void Initialize()
    {
        m_SR = GetComponent<SpriteRenderer>();
        m_SR.color = m_NoteInitData.Data.Color;
        transform.localScale = new Vector3(m_NoteInitData.NoteSize, m_NoteInitData.NoteSize, 0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(m_NoteInitData.Data.InputKey) && m_CanBePressed)
        {
            OnHit();
        }
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Indicator")
        {
            m_CanBePressed = true;
        }
        if (other.tag == "EndLane")
        {
            OnFinish();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Indicator")
        {
            m_CanBePressed = false;
        }
    }

    public void OnFinish()
    {
        Destroy(this.gameObject);
    }

    public void OnHit()
    {
        GameEventHelper.OnAddScore?.Invoke(m_NoteInitData.Data.Score);
        Destroy(this.gameObject);
    }

    public void Move()
    {
        m_Time += Time.deltaTime / m_NoteInitData.LeadInTime;
        transform.position = Vector3.Lerp(m_NoteInitData.SpawnPosition, m_NoteInitData.DespawnPosition, m_Time);
    }

}
