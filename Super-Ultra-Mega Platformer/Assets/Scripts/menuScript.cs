using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class menuScript : MonoBehaviour
    {

        public Button scene1Text;

        // Use this for initialization
        void Start()
        {
            //scene1Text = scene1Text.GetComponent<Button>();
        }

        public void scene1Press()
        {
            SceneManager.LoadScene("ability_select_1");
        }
		
		public void exitPress() 
		{
			Application.Quit();
		}
    }
}
