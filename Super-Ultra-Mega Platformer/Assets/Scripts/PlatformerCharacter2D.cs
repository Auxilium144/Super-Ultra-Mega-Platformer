using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [Range(0, 1)] [SerializeField] private float m_WaterSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
        [SerializeField] private LayerMask m_WhatIsWater;                  // A mask determining what is water to the character
        [SerializeField] protected bool AbilityEnable;                  // are abilities allowed?

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private bool m_Water;            // Whether or not the player is Watered.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
        private int m_jumps = 0; //holds jump charges
        private int NumJumps = 0;
        //private bool m_doubleJumpEnable; //enables double jumps
        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public bool getAbilityEnable()
        {
            return AbilityEnable;
        }
        public void setNumJumps(int pie)
        {
            if(pie == 0)
            {
                NumJumps = 1;
            }
            else
            {
                NumJumps = 0;
            }
        }
        private void FixedUpdate()
        {
            m_Grounded = false;
            m_Water = false;

            // The player is grounded or water if a circlecast to the groundcheck position hits anything designated as ground or water
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                }
            }
            Collider2D[] waters = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsWater);
            for (int i = 0; i < waters.Length; i++)
            {
                if (waters[i].gameObject != gameObject)
                {
                    m_Water = true;
                }
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
        }


        public void Move(float move, bool crouch, bool jump, bool[] AbilityList)
        {
            
            // If crouching, check to see if the character can stand up
            if (!crouch && m_Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }

            // Set whether or not the character is crouching in the animator
            m_Anim.SetBool("Crouch", crouch);

            //only control the player if grounded, airControl, m_Water is turned on
            if (m_Grounded || m_AirControl || m_Water)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*m_CrouchSpeed : move);
                // Reduce the speed if in water by the water multiplier
                if (m_Water)
                {
                    move = (move * m_WaterSpeed);
                }
                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));
                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Water && jump && m_Anim.GetBool("Ground"))
            {
                // reduced jump velocity due to water
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce/4));
                m_jumps = 1;
                Debug.Log("jump from water");
            }
            else if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                Debug.Log("jump from ground");
                m_jumps = NumJumps;
            }
            else if (!m_Grounded && (m_jumps > 0) && AbilityList[0]) //&& !m_Anim.GetBool("Ground")
            {
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce/2));
                m_jumps = m_jumps - 1;
                Debug.Log("jump from air");
            }
            if(m_Grounded && AbilityList[1]) // dash forward/right
            {
                m_Rigidbody2D.AddForce(new Vector2(1000f, 0f));
            }
            if (m_Grounded && AbilityList[2]) // dash backwards/left
            {
                m_Rigidbody2D.AddForce(new Vector2(-1000f, 0f));
            }
            if (m_Grounded && AbilityList[3]) // dash forward/right
            {
                m_Grounded = false;
                m_Rigidbody2D.AddForce(new Vector2(1000f, 400f));
            }
            // Move the character
            m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);
            Debug.Log("The current move value is equal to " + move * m_MaxSpeed);
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}

/*
 * 0 Double Jump
 * 1 Dash Forward (PlaceHolder)
 * 2 Dash Backward (PlaceHolder)
 * 3 Lunge right(PlaceHolder)
 * 4
 * 5
 * 6
 * 7
 * 8
 * 9
 * 10
 */