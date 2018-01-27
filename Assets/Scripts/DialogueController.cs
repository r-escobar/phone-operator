using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SpeakerPair {
	public Speaker speaker1;
	public Speaker speaker2;
}

[System.Serializable]
public class Speaker {
	public string name;
	public Color color;
	public string[] rambling;
	public string matchTest;
	public string correctMatchResponse;
	public string wrongMatchResponse;
}

public class DialogueController : MonoBehaviour {

	public SpeakerPair test;

	void Start()
	{
		test = LoadSpeakerPair();
	}

	public SpeakerPair LoadSpeakerPair()
	{
		string file = "Convo-Billy";
		TextAsset asset = Resources.Load (Path.Combine ("Dialogue", file)) as TextAsset;
		SpeakerPair sp = JsonUtility.FromJson<SpeakerPair> (asset.text);
		return sp;
	}
}
