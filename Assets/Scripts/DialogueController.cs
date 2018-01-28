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


public enum SpeakerFrom {NewPair, PairOnBoard};

public class DialogueController : MonoBehaviour {

	public List<SpeakerPair> speakerPairs;
	public List<List<SpeakerFrom>> waveSources;

	void Start()
	{
		for(int i = 1; i <= 30; i++) {
			speakerPairs.Insert(i-1, LoadSpeakerPair(1));
		}
		NextWave();
	}

	public SpeakerPair LoadSpeakerPair(int i)
	{
		string file = "Convo" + i;
		TextAsset asset = Resources.Load (Path.Combine ("Dialogue", file)) as TextAsset;
		SpeakerPair sp = JsonUtility.FromJson<SpeakerPair> (asset.text);
		return sp;
	}

	public void NextWave() {

	}
}
