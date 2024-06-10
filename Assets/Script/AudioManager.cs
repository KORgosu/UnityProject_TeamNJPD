using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;
    AudioHighPassFilter bgmLvUP; // 레벨업 할 시 소리를 변화시키기 위한 변수 지정

    [Header("#SFX")] // 효과음
    public AudioClip[] sfxClips;
    public float sfxVolume;
    AudioSource[] sfxPlayers;
    public int channels;
    int channelIndex;

    public enum Sfx { Dead, Hit, LevelUp = 3, Lose, Melee, Range = 7, Select, Win }

    private void Awake()
    {
        instance = this;
        Init();
    }

     void Init()
    {
        // 배경음 초기화
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;
        bgmLvUP = Camera.main.GetComponent<AudioHighPassFilter>();

        // 효과음 초기화
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].bypassListenerEffects = true;
            sfxPlayers[i].volume = sfxVolume;
           
        }
    }

    public void PlayBgm(bool isPlay) // 배경음 시스템
    {
        if (isPlay)
        {
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }

    public void LvUpBgm(bool isPlay) // 배경음 시스템
    {
        bgmLvUP.enabled = isPlay;
    }

    public void PlaySfx(Sfx sfx) // 효과음 시스템
    {
        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            int loopIndex = (i + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying) // 재생하고 있는 효과음이 있는 경우
            {
                continue;
            }

            
            int ranIndex = 0;
            if (sfx == Sfx.Hit || sfx == Sfx.Melee)
            {
                ranIndex = Random.Range(0, 2); // Hit 와 Melee 는 SFX 2개중 하나 랜덤으로 재생, 그이상으로 SFX가 많으면 switch 문으로 전환할것
            }
            

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx + ranIndex];
            sfxPlayers[loopIndex].Play();

            break; // 효과음 재생 종료
        }
    }
}
