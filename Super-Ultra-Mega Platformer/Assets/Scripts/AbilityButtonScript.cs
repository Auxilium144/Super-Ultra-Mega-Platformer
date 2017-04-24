using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;
namespace UnityStandardAssets._2D
{
    public class AbilityButtonScript : MonoBehaviour
    {
		public string level;
        public Button ability1;
        public Button ability2;
        public Button ability3;
        public Button ability4;
        public Button ability5;
        public Button ability6;
        public Button ability7;
		public Button ability8;
		public Button enterStage;
		public Button back;
		public Button flushAbilities;
        private int abilitiesCount;
        private string[] abilities;
        string path;

        void Start()
        {
            abilitiesCount = 0;
            abilities = new string[4];
            path = Directory.GetCurrentDirectory();
        }
		
		public void backPress() 
		{
			SceneManager.LoadScene("Stage_Select");
		}
		
		public void enterPress()
		{
			System.IO.File.WriteAllLines(path + "abilities.txt", abilities);
			SceneManager.LoadScene(level);
		}
		
		public void resetAbilities() 
		{
			abilitiesCount = 0;
			abilities = new string[4];
			ability1.enabled = true;
			ability2.enabled = true;
			ability3.enabled = true;
			ability4.enabled = true;
			ability5.enabled = true;
			ability6.enabled = true;
			ability7.enabled = true;
			ability8.enabled = true;
			
		}

        public void ability1Press()
        {
            abilityHandler("0");
            ability1.enabled = false;
        }

        public void ability2Press()
        {
            abilityHandler("1");
            ability2.enabled = false;
        }

        public void ability3Press()
        {
            abilityHandler("2");
            ability3.enabled = false;
        }

        public void ability4Press()
        {
            abilityHandler("3");
            ability4.enabled = false;
        }

        public void ability5Press()
        {
            abilityHandler("4");
            ability5.enabled = false;
        }

        public void ability6Press()
        {
            abilityHandler("5");
            ability6.enabled = false;
        }

        public void ability7Press()
        {
            abilityHandler("6");
            ability7.enabled = false;
        }
		
		public void ability8Press()
		{
			 abilityHandler("7");
            ability8.enabled = false;
		}

        private void abilityHandler(string ability)
        {
            if (abilitiesCount <= 2)
            {
                abilities[abilitiesCount] = ability;
                abilitiesCount++;
            }
            else
            {
                abilities[abilitiesCount] = ability;
                System.IO.File.WriteAllLines(path + "abilities.txt", abilities);
                SceneManager.LoadScene(level);
            }
        }
		
		
    }
}
