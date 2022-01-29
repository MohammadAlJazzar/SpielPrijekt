using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Audio jump;
    public Audio score;
    public Audio lose;



    public static SoundManager Instance;

    private void Awake()
    {
        if(Instance== null)
        {
            Instance =this;
            DontDestroyOnLoad(gameObject);


        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
        
    }

    public void PlaySound(Audio audio)
    {
        audioSource.PlayOneShot(audio.clip, audio.volume);
    }
    [System.Serializable]
    public class Audio
    {
        public AudioClip clip;
        [Range(0,1)]
        public float volume;

    }

    
   public void ChangeVolume()
   {
       AudioListener.volume = volumeSlider.value;
       Save();

   }

   private void Load()
   {
       volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");

   }

   private void Save()
   {
       PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);

   }
}
