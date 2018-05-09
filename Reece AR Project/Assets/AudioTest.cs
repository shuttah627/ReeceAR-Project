using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour {
    public AudioClip tester;
    public GameObject Base;

    public void TestAudio()
    {
        Base.GetComponent<BaseController>()._audioController.GetComponent<AudioController>().AddToQueue(tester);
    }
}
