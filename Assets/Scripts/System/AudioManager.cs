﻿using UnityEngine;
using System.Collections;


[System.Serializable]

public class Sound
{

    public string theName;
    public AudioClip clip;


    [HideInInspector]
    public int ID = -1;

    AudioSource source;


    [Range(0f, 1f)]
    public float defaultVolume = 0.7f;

    public float duration;
    float volume;

    [Range(0.5f, 2f)]
    public float pitch = 1;


    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;

    public bool loop;
    float fadeFrom, fadeTo, fadeStep;
    bool fadeIn;

    float currentVolume;

    public Sound(Sound s)
    {
        theName = s.theName;
        clip = s.clip;
        defaultVolume = s.defaultVolume;
        duration = s.duration;
        pitch = s.pitch;
        randomPitch = s.randomPitch;
        randomVolume = s.randomVolume;
        loop = s.loop;
    }

    public void SetSource(AudioSource _source)
    {
        //inizializzazione suono
        source = _source;


        source.clip = clip;
        source.volume = defaultVolume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        currentVolume = source.volume;

        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.loop = loop;
        // duration = clip.length;


    }

    public bool PlaySound()
    {


        //riproduzione

        if (source.isPlaying)
        {
            return false;

        }
        else
            source.Play();

        return true;
    }

    public bool IsPlaying()
    {

        if (source.isPlaying)
        {
            return true;

        }

        return false;
    }

    public bool PlaySound(int soundID)
    {


        //riproduzione
        if (source.isPlaying)
        {
            return false;

        }
        else
        {
            ID = soundID;
            source.Play();
        }

        return true;
    }


    public void StopSound()
    {
        source.Stop();
        ID = -1;
    }

    //public IEnumerator StopSoundDelay(float time)
    //{
    //    if (duration <= 0)
    //        yield break;
    //    else { 
    //    yield return new WaitForSeconds(time);


    //        source.Stop();}

    //}

    public void SetVolume(float _volume)
    {
        source.volume = _volume;

    }


    public void CurrentVolume()
    {
        source.volume = currentVolume;

    }

    public void Pause()
    {
        if (source.isPlaying)
        {
            source.Pause();
        }
        else source.UnPause();
    }

    public void Fade(float to, float step)
    {
        //fadeFrom = from;
        if (to == 0)
            fadeTo = to + step * Time.deltaTime;
        else
            fadeTo = to;
        fadeStep = step;
        if (to > source.volume)
        {
            fadeIn = true;
        }

        else fadeIn = false;

    }

    public bool Fading()
    {
        float tmpVol;
        if (fadeIn)
        {
            if (source.volume <= fadeTo)
            {
                source.volume += fadeStep * Time.deltaTime;
                return false;
            }
            else return true;
        }
        else
        {

            if (source.volume >= fadeTo)
            {
                tmpVol = source.volume - fadeStep * Time.deltaTime;
                if (tmpVol < 0)
                    tmpVol = 0;

                source.volume = tmpVol;
                Debug.Log("in");
                return false;

            }
            else
            {
                source.volume = fadeTo;
                return true;
            }
        }
    }

}

public class AudioManager : MonoBehaviour
{
    bool musicOn = true;

    //Inserire i suoni nell'editor
    [SerializeField]
    Sound[] sounds;

    //Sound[] usingSounds;
    int currentID = 0;

    [SerializeField]
    Sound[] musics;

    Sound[] fadingMusics = new Sound[2];



    public static AudioManager instance;
    void Awake()
    {


        if (instance != null)
        {

            if (instance != this)
                Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }


    }

    // Use this for initialization
    void Start()
    {




        for (int i = 0; i < sounds.Length; i++)
        {


            GameObject _go = new GameObject("Sound_" + i + sounds[i].theName);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
            _go.transform.SetParent(this.transform);


        }


        for (int i = 0; i < musics.Length; i++)
        {


            GameObject _go = new GameObject("Music_" + i + musics[i].theName);
            musics[i].SetSource(_go.AddComponent<AudioSource>());
            _go.transform.SetParent(this.transform);


        }

        if (PlayerPrefs.GetInt("MusicState") == 2)
        {
            MusicsActivation(false);
            musicOn = false;
        }

        if (PlayerPrefs.GetInt("SoundState") == 2)
        {
            SoundsActivation(false);
        }


    }



    void Update()
    {
        if (musicOn)
        {
            for (int p = 0; p < fadingMusics.Length; p++)
            {
                if (fadingMusics[p] != null)
                {
                    if (fadingMusics[p].Fading())
                    {
                        fadingMusics[p] = null;
                        Debug.Log("done");
                    }
                }
            }
        }
    }

    public void PlaySound(string soundName)
    {

        //chiamata del suono tramite nome
        if (soundName.ToCharArray()[0] == 'S')
        {
            for (int i = 0; i < sounds.Length; i++)
            {


                if (sounds[i].theName.Contains(soundName))
                {

                    if (sounds[i].PlaySound())
                    {
                        //      StartCoroutine(usingSounds[i].StopSoundDelay());
                        return;
                    }
                    else
                    {
                        sounds[i].StopSound();
                        sounds[i].PlaySound();
                        return;
                    }


                }


            }
        }


        //in alternativa cerca la musica

        else
        {

            for (int i = 0; i < musics.Length; i++)
            {

                //ricerca del suono

                if (musics[i].theName.Contains(soundName))
                {
                    //stop suono
                    if (musics[i].PlaySound())
                        return;
                }
            }
        }


        //  Debug.LogError("Sound " + soundName + " doesn't exist");
    }



    public int PlaySoundWithID(string soundName)
    {
        int tmpID;

        if (soundName.ToCharArray()[0] == 'S')
        {
            for (int i = 0; i < sounds.Length; i++)
            {



                if (sounds[i].theName.Contains(soundName) && sounds[i].ID == -1)
                {
                    if (sounds[i].PlaySound(currentID))
                    {
                        tmpID = currentID;
                        if (currentID > 2)
                            currentID = 0;
                        else
                            currentID++;
                        return tmpID;
                    }


                }


            }
        }
        return -1;
    }




    public void StopSound(string soundName)
    {


        //chiamata del suono tramite nome

        if (soundName.ToCharArray()[0] == 'S')
        {

            for (int i = 0; i < sounds.Length; i++)
            {
                //ricerca del suono


                if (sounds[i].theName.Contains(soundName))
                {
                    //ricerca del suono


                    sounds[i].StopSound();
                    return;
                }
            }
        }

        else

        {
            for (int i = 0; i < musics.Length; i++)
            {
                //ricerca del suono


                if (musics[i].theName == soundName)
                {
                    //stop suono

                    musics[i].StopSound();
                    return;
                }
            }
        }



        Debug.LogError("Sound " + soundName + " doesn't exist");
    }

    public void StopSound(string soundName, int soundID)
    {


        //chiamata del suono tramite nome

        if (soundName.ToCharArray()[0] == 'S')
        {

            for (int i = 0; i < sounds.Length; i++)
            {
                //ricerca del suono

                if (sounds[i].theName.Contains(soundName) && soundID == sounds[i].ID)
                {
                    Debug.Log(soundName);

                    //ricerca del suono
                    sounds[i].StopSound();
                    return;
                }
            }
        }

        Debug.LogError("Sound " + soundName + " doesn't exist");
    }



    public void setVolume(string soundName, float volume)
    {

        //chiamata del suono tramite nome
        if (musicOn)
        {

            for (int i = 0; i < musics.Length; i++)
            {

                //ricerca del suono

                if (musics[i].theName == soundName)
                {

                    //modifica volume
                    musics[i].SetVolume(volume);
                    return;
                }
            }

            Debug.LogError("Music " + soundName + " doesn't exist");
        }
    }

    public void SoundsActivation(bool setOn)
    {

        for (int i = 0; i < sounds.Length; i++)
        {

            if (!setOn)
            {
                sounds[i].SetVolume(0);
                PlayerPrefs.SetInt("SoundState", 2);
            }
            else
            {
                sounds[i].CurrentVolume();
                PlayerPrefs.SetInt("SoundState", 1);

            }

        }

    }


    public void StopAllSounds()
    {

        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].StopSound();


        }

    }



    public void MusicsActivation(bool setOn)
    {

        for (int i = 0; i < musics.Length; i++)
        {

            if (!setOn)
            {
                musics[i].SetVolume(0);
                PlayerPrefs.SetInt("MusicState", 2);
                musicOn = false;

            }
            else
            {
                musics[i].CurrentVolume();
                PlayerPrefs.SetInt("MusicState", 1);
                musicOn = true;
            }

        }

    }

    public void stopAllMusic()
    {

        for (int i = 0; i < musics.Length; i++)
        {

            musics[i].StopSound();

        }

    }

    public bool StopIfDifferent(string soundName)
    {

        for(int i=0; i<musics.Length; i++)
        {
            if (musics[i].theName == soundName)
            {
                if(musics[i].IsPlaying())
                return false;
            }
        }
        StopAllSounds();
        return true;
    }

    public void PauseSound(string soundName)
    {


        for (int i = 0; i < musics.Length; i++)
        {

            //ricerca del suono

            if (musics[i].theName == soundName)
            {

                //modifica volume
                musics[i].Pause();
                return;
            }
        }

    }


    public void FadeMusic(string soundName, float to, float fadeSpeed)
    {
        if (musicOn)
        {

            for (int i = 0; i < musics.Length; i++)
            {

                //ricerca del suono

                if (musics[i].theName == soundName)
                {

                    //modifica volume
                    musics[i].Fade(to, fadeSpeed);
                    for (int k = 0; k < fadingMusics.Length; k++)
                    {

                        if (fadingMusics[k] == null)
                        {
                            fadingMusics[k] = musics[i];
                            return;
                        }
                    }
                    return;
                }
            }
        }

    }





}

