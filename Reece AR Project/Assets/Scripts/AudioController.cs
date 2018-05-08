using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    protected Queue<AudioClip> _audioQueue;
    public string _audioObjectSuffix = "_AudioObject";

    void Start()
    {
        _audioQueue = new Queue<AudioClip>();
    }

    void FixedUpdate() // Not exactly the best way, but good enough for this stage of development.
    {
        if (_audioQueue.Count > 0)
        {
            StartCoroutine(CheckQueue());
        }
    }

    public void AddToQueue(AudioClip _audioClip)
    {
        _audioQueue.Enqueue(_audioClip);
    }

    IEnumerator CheckQueue()
    {
        for (int i = 0; i < _audioQueue.Count; i++)
        {
            StartCoroutine(PlaySound(_audioQueue.Dequeue()));
        }
        yield return null;
    }

    IEnumerator PlaySound(AudioClip _audioClip)
    {
        GameObject _tempObj = new GameObject(_audioClip.name+_audioObjectSuffix);
        AudioSource _tempSource = _tempObj.AddComponent<AudioSource>();
        _tempSource.clip = _audioClip;
        _tempSource.Play();
        Destroy(gameObject, _audioClip.length);
        yield return null;        
    } 
	
}
