using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
   
   
   [Header("Confirmation")] 
   [SerializeField] private GameObject confirmationPrompt = null;
   
   [Header("Levels To Load")] 
   
   public string _newGameLevel;

   private string levelToLoad;

   [SerializeField] private GameObject noSavedGameDialog = null;

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

   public void ResetButton(string MenuType)
   {
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
