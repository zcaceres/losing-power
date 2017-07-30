using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundController : MonoBehaviour {
	public AudioClip[] audioclips = new AudioClip[2];
	AudioSource source;

	void Awake () {
		source = GetComponent<AudioSource>();
	}

	void PlaySound() {
		if (source.isPlaying) {
			return;
		}
		ChooseClip();
		source.Play();
	}

	void ChooseClip() {
		source.clip = audioclips[Random.Range(0, audioclips.Length)];
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			if (Random.Range(0, 10) < 5) {
				PlaySound();
			}
		}
	}

}
