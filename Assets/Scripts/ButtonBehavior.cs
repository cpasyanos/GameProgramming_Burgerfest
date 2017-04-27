using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour {

   public void quitButton()
   {
      Debug.Log("quitted");
      Application.Quit();
   }

   public void replay()
   {
      Debug.Log("reloaded");
      SceneManager.LoadScene("final_demo");
   }

}