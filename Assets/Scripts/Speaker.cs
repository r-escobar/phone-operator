using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Speaker {
	public string speakerName;
	public Color color;
	public string[] rambling;
	public string matchTest;
	public string correctMatchResponse;
	public string wrongMatchResponse;
}

[System.Serializable]
public class SpeakerPair {
	public Speaker speaker1;
	public Speaker speaker2;
}