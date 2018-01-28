using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueController : MonoBehaviour {

	public List<SpeakerPair> speakerPairs;
	public List<Speaker> speakersWhosePairsAreOnBoard;
	public List<JackController> jacks;
	int curJackIndex;

	public List<string> speakersPerWave;
    // 'N' corresponds with getting a speaker from a NEW pair (i.e. it's partner hasn't been put on the board yet)
    // 'U' corresponds with getting a speaker from a USED par (i.e. it's partner is on the board)

	public int curWave;

	void Start()
	{
		foreach(GameObject j in GameObject.FindGameObjectsWithTag("Jack")) {
			jacks.Add(j.GetComponent<JackController>());
		}
		curJackIndex = 0;

		curWave = 0;
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
		print("Called NextWave, curWave"  + curWave);

		string curWaveSpeakers = speakersPerWave[curWave];

		if(curWaveSpeakers == null) {
			print("Waves over!");
			return;
		}

		for(int i = 0; i < curWaveSpeakers.Length; i++) {
			switch (curWaveSpeakers[i])
			{
				case 'N':
					AddSpeakerOfNewPairToBoard();
					break;
				case 'U':
					AddSpeakerWhosePairIsOnBoardToBoard();
					break;
				default:
					print("Next speaker source is neither acceptable option.");
					break;
			}
		}
		curWave++;

		Invoke("NextWave", 10);
	}

	void AddSpeakerOfNewPairToBoard() {
		SpeakerPair pairToLoad = speakerPairs[0];
		speakerPairs.RemoveAt(0);

		jacks[curJackIndex].ReceiveNewSpeaker(pairToLoad.speaker1);
		curJackIndex = (curJackIndex + 1) % jacks.Count;

		speakersWhosePairsAreOnBoard.Add(pairToLoad.speaker2);
	}

	void AddSpeakerWhosePairIsOnBoardToBoard() {

		int randomPartnerIndex = Random.Range(0,speakersWhosePairsAreOnBoard.Count);
		Speaker partnerToLoad = speakersWhosePairsAreOnBoard[randomPartnerIndex];
		speakersWhosePairsAreOnBoard.RemoveAt(randomPartnerIndex);

		jacks[curJackIndex].ReceiveNewSpeaker(partnerToLoad);
		curJackIndex = (curJackIndex + 1) % jacks.Count;
	}

}
