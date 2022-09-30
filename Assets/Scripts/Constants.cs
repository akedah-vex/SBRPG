using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameConstants
{
    /// <summary>
    /// Class containing constants for scene management
    /// </summary>
    public static class Scenes
    {
        /// <summary>
        /// The main menu scene
        /// </summary>
        public const string MAIN_MENU = "MainMenu";

        /// <summary>
        /// The dev join menu scene
        /// </summary>
        public const string DEV_JOIN_MENU = "DevJoinMenu";
        
        /// <summary>
        /// The game scene
        /// </summary>
        public const string GAME = "Game";
    }

    public static class Player
    {
        /// <summary>
        /// True if player is sprinting
        /// </summary>
        public const bool IS_BOOSTING = false;
    }

    public static class Areas
    {
        /// <summary>
        /// The main menu area
        /// </summary>
        public const string MAIN_MENU = "Main Menu";
        
        /// <summary>
        /// The dev room area
        /// </summary>
        public const string DEV_ROOM = "Dev Room";
    }

    
}
