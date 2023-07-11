using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using Toggle = UnityEngine.UI.Toggle;

public class MenuController : MonoBehaviour
{
   [Header("Volume Settings")] 
   
   [SerializeField] private TMP_Text volumeTextValue = null;
   [SerializeField] private Slider volumeSlider = null;
   [SerializeField] private float defaultVolume = 1.0f;

   [Header("Gameplay Settings")] 
   [SerializeField] private TMP_Text ControllerSenTextValue = null;
   [SerializeField] private Slider controllerSenSlider = null;
   [SerializeField] private int defaultSen = 4;
   public int mainControllerSen = 4;

   [Header("Toggle Settings")] 
   [SerializeField] private Toggle invertYToggle = null;
   
   [Header("Graphics Settings")] 
   [SerializeField] private Slider brightnessSlider = null;
   [SerializeField] private TMP_Text brightnessTextValue = null;
   [SerializeField] private float defaultBrightness = 1;

   [Space(10)] 
   [SerializeField] private TMP_Dropdown qualityDropdown;

   [SerializeField] private Toggle fullScreenToggle;

   private int _qualityLevel;
   private bool _isFullScreen;
   private float _brightnessLevel;

   
   [Header("Confirmation")] 
   [SerializeField] private GameObject confirmationPrompt = null;
   
   [Header("Levels To Load")] 
   
   public string _newGameLevel;
   private string levelToLoad;
   [SerializeField] private GameObject noSavedGameDialog = null;

   [Header("Resolution Dropdowns")] 
   public TMP_Dropdown resolutionDropdown;
   private Resolution[] resolutions;

   private void Start()
   {
      resolutions = Screen.resolutions;
      resolutionDropdown.ClearOptions(); //get rid of default values

      List<string> options = new List<string>();  //list of options
      int currentResolutionIndex = 0;

      for (int i = 0; i < resolutions.Length; i++) 
      {
         string option = resolutions[i].width + " x " + resolutions[i].height; 
         options.Add(option);

         if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
         {
            currentResolutionIndex = i;
         }
      }
      resolutionDropdown.AddOptions(options);
      resolutionDropdown.value = currentResolutionIndex;
      resolutionDropdown.RefreshShownValue();
   }
   
   public void SetResolution(int resolutionIndex)
   {
      Resolution resolution = resolutions[resolutionIndex];
      Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
   }
   

   public void NewGameDialogYes()
   {
      SceneManager.LoadScene(_newGameLevel);
   }

   public void LoadGameDialogYes()
   {
      if (PlayerPrefs.HasKey("SavedLevel"))
      {
         levelToLoad = PlayerPrefs.GetString("SavedLevel");
         SceneManager.LoadScene(levelToLoad);
      }
      else
      {
         noSavedGameDialog.SetActive(true);
      }
   }
   public void QuitGame()
   {
      Debug.Log("QUIT!");
      Application.Quit();
   }
   //Voice Slider Setting
   public void SetVolume(float volume)
   {
      AudioListener.volume = volume;
      volumeTextValue.text = volume.ToString("0.0");
   }
    
   //to save the volume
   public void VolumeApply()
   {
      PlayerPrefs.SetFloat("masterVolume" , AudioListener.volume);
      //Show Prompt  
      StartCoroutine(ConfirmationBox());
   }

   public void SetControllerSen(float sensitivity)  //slider 
   {
      mainControllerSen = Mathf.RoundToInt(sensitivity); // yuvarlama işlemi için
      ControllerSenTextValue.text = sensitivity.ToString("0");
   }

   public void GameplayApply() //Toggle
   {
      if (invertYToggle.isOn)
      {
         PlayerPrefs.SetInt("masterInvertY", 1); //1 doğru ise 0 yanlıştır
         //invert Y
      }
      else ;
      {
         PlayerPrefs.SetInt("masterInvertY",0);
         //Not invert
      }
      
      PlayerPrefs.SetFloat("masterSen", mainControllerSen);
      StartCoroutine(ConfirmationBox());
   }

   public void SetBrightness(float brightness)
   {
      _brightnessLevel = brightness;
      brightnessTextValue.text = brightness.ToString("0.0");
   }

   public void SetFullScreen(bool isFullScreen)
   {
      _isFullScreen = isFullScreen;
   }

   public void SetQuality(int qualityIndex)
   {
      _qualityLevel = qualityIndex;
   }

   public void GraphicsApply()
   {
      PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel);
      //Change your brightness with your post processing or whatever it is
      
      PlayerPrefs.SetInt("masterQuality", _qualityLevel);
      QualitySettings.SetQualityLevel(_qualityLevel);
      
      PlayerPrefs.SetInt("masterFullscreen", (_isFullScreen ? 1 : 0)); // true-false
      Screen.fullScreen = _isFullScreen;

      StartCoroutine(ConfirmationBox());
   }
   
   public void ResetButton(string MenuType)
   {
      if (MenuType == "Graphics")
      {
         //Reset brightness value
         brightnessSlider.value = defaultBrightness;
         brightnessTextValue.text = defaultBrightness.ToString("0.0");

         qualityDropdown.value = 1;  // start with medium quality
         QualitySettings.SetQualityLevel(1);

         fullScreenToggle.isOn = false;
         Screen.fullScreen = false;

         Resolution currentResolution = Screen.currentResolution;
         Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
         resolutionDropdown.value = resolutions.Length;
         GraphicsApply();
      }
      
      if (MenuType == "Audio")
      {
         AudioListener.volume = defaultVolume;
         volumeSlider.value = defaultVolume;
         volumeTextValue.text = defaultVolume.ToString("0.0");
         VolumeApply(); //to save it
      }

      if (MenuType == "Gameplay")
      {
         ControllerSenTextValue.text = defaultSen.ToString("0");
         controllerSenSlider.value = defaultSen;
         mainControllerSen = defaultSen;
         invertYToggle.isOn = false;
         GameplayApply();
      }
   }

   public IEnumerator ConfirmationBox()
   {
      confirmationPrompt.SetActive(true);
      yield return new WaitForSeconds(2);
      confirmationPrompt.SetActive(false);
   }
    
}
