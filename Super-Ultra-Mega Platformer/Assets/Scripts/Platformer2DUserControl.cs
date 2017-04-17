using System;
using System.IO;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool[] AbilityList = new bool[]{ false, false, false, false, false, false, false, false, false, false }; //10 list of ability and if they are enabled, all false unless called
        private bool[] m_Ability = new bool[] { false, false, false, false }; // input controls and sets up current ability usage asdw
        private int[] equippedAbility = new int[] { 0, 7, 3, 2, 100}; //4 currently equipped abilities in order of asdw EX: 1, 4, 5, 6,
        private int currentAbility = 0; //currently equipped and allowed to be excuted
        private int pressedKey;
        //private string[] inputList = ;
        public void setEquippedAbility(int[] list)//sets equipped abilities
        {
            for(int i=0; i<4; i++)
            {
                equippedAbility[i] = list[i];
            }
        }

        private void Awake() //Perform on character creation
        {
			//getAbilityList(); //Refers abilityId list
			
            m_Character = GetComponent<PlatformerCharacter2D>();
			
			
        }

        private void setOther(int x)
        {
            //Set other abilites to zero
            for(int i = 0; i<4; i++)
            {
                if (i != x)
                {
                    m_Ability[i] = false;
                }
                else if(i == x)
                {
                    m_Ability[i] = true;
                    currentAbility = equippedAbility[x];
                    Debug.Log("Ability is set " + currentAbility);
                }
                else
                {
                    Debug.Log("Not setting m_Ability Properly");
                }
            }
        }

        private void setFalseList(int x)
        {
            //Set other abilites to zero
            for (int i = 0; i < 10; i++)
            {
                if (i != x)
                {
                    AbilityList[i] = false;
                }
            }
        }
        private int readinput()
        {
            //Debug.Log("reading input...");
            if (CrossPlatformInputManager.GetButtonDown("Ability0"))
            {
                Debug.Log("input was key a");
                return 0;
            }
            else if (CrossPlatformInputManager.GetButtonDown("Ability1"))
            {
                Debug.Log("input was key s");
                return 1;
            }
            else if (CrossPlatformInputManager.GetButtonDown("Ability2"))
            {
                Debug.Log("input was key d");
                return 2;
            }
            else if (CrossPlatformInputManager.GetButtonDown("Ability3"))
            {
                Debug.Log("input was key w");
                return 3;
            }
            else
            {
                //Debug.Log("Sending output of reading");
                return 4;
            }
        }

        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump"); //key space

            }
            // Changes abilities between eachother
            if (m_Character.getAbilityEnable() && !(currentAbility == equippedAbility[readinput()])) // Changes Abilities by setting other keys to false and that key to true
            {
                //Debug.Log("current " + currentAbility);
                pressedKey = readinput();
                if (pressedKey == 0)
                {
                    setOther(0); //make sure other inputs are not read and sets current input to true
                    Debug.Log("Ability 0 is enabled");

                }
                else if (pressedKey == 1)
                {
                    setOther(1);
                    Debug.Log("Ability 1 is enabled");
                }
                else if (pressedKey == 2)
                {
                    setOther(2);
                    Debug.Log("Ability 2 is enabled");
                }
                else if (pressedKey == 3)
                { 
                    setOther(3);
                    Debug.Log("Ability 3 is enabled, and ability id is " + currentAbility);
                }

            }
            else if (CrossPlatformInputManager.GetButtonDown("Ability0") && currentAbility == equippedAbility[0]) //flags Ability 0
            {
                //m_doubleJump = CrossPlatformInputManager.GetButtonDown("Ability1");
                AbilityList[equippedAbility[0]] = true; //ex: asks m_character to perform ability 1
                setFalseList(equippedAbility[0]);
            }
            else if (CrossPlatformInputManager.GetButtonDown("Ability1") && currentAbility == equippedAbility[1]) //flags Ability 1
            {

                AbilityList[equippedAbility[1]] = true; //ex: asks m_character to perform ability 4
                setFalseList(equippedAbility[1]);
            }
            else if (CrossPlatformInputManager.GetButtonDown("Ability2") && currentAbility == equippedAbility[2]) //flags Ability 2
            {

                AbilityList[equippedAbility[2]] = true;//ex: asks m_character to perform ability 5
                setFalseList(equippedAbility[2]);
            }
            else if (CrossPlatformInputManager.GetButtonDown("Ability3") && currentAbility == equippedAbility[3]) //flags Ability 3
            {
                AbilityList[equippedAbility[3]] = true;//ex: //asks m_character to perform ability 6
                setFalseList(equippedAbility[3]);
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            //Debug.Log(AbilityList[5]);
            m_Character.Move(h, crouch, m_Jump, AbilityList, currentAbility);
            //Debug.Log(currentAbility + " after ");
            m_Jump = false;
            setFalseList(4);
        }
		
		private void getAbilityList() 
		{
			string path = Directory.GetCurrentDirectory();
			string[] lines = System.IO.File.ReadAllLines(path + "abilities.txt");
			for (int i = 0; i <= 3; i++) 
			{
				equippedAbility[i] = Int32.Parse(lines[i]);
				Debug.Log("Stuff" + lines[i]);
				Debug.Log("other: " + equippedAbility[i]);
			}
			
		}
    }
}
