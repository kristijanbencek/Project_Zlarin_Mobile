using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Aclip", menuName = "AudioClips")]
public class AudioSources : ScriptableObject
{
    public string TextArea = "Sound used on any button in the app";
    public AudioClip buttonClip;
}
