using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    private float _noteVelocity;
    public System.Action OnNoteIndicator;

    // Start is called before the first frame update
    void Start()
    {
        _noteVelocity = 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _noteVelocity * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}