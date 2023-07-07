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

   public void ResetButton(string MenuType)
   {
      if (MenuType == "Audio")
      {
         AudioListener.volume = defaultVolume;
         volumeSlider.value = defaultVolume;
         volumeTextValue.text = defaultVolume.ToString("0.0");
         VolumeApply(); //to save it
      }
   }

   public IEnumerator ConfirmationBox()
   {
      confirmationPrompt.SetActive(true);
      yield return new WaitForSeconds(2);
      confirmationPrompt.SetActive(false);
   }
    
}
