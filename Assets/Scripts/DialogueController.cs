using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueController : MonoBehaviour {

	public List<SpeakerPair> speakerPairs;
	public List<string> speakersPerWave;
	// 'N' corresponds with getting a speaker from a NEW pair (i.e. it's partner hasn't been put on the board yet)
	// 'U' corresponds with getting a speaker from a USED par (i.e. it's partner is on the board)

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
