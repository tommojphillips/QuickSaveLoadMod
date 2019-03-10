using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MSCLoader;

namespace TommoJProductions.QuickSaveLoadMod
{
    /// <summary>
    /// Represents quick save function
    /// </summary>
    internal class QuickSaveLoadMono : MonoBehaviour
    {
        // Written, 09.03.2019

        #region Fields
        
        /// <summary>
        /// Represents the time.
        /// </summary>
        private float time;
        
        #endregion

        #region Properties

        /// <summary>
        /// Represents if quick load has been requested.
        /// </summary>
        private bool requestedQuickLoad
        {
            get;
            set;
        }
        /// <summary>
        /// Represents if quick save has been requested.
        /// </summary>
        private bool requestedQuickSave
        {
            get;
            set;
        }
        /// <summary>
        /// Represents quick save primary key.
        /// </summary>
        internal KeyCode quickSavePrimaryKey
        {
            get;
            set;
        }
        /// <summary>
        /// Represents quick save secondary key.
        /// </summary>
        internal KeyCode quickSaveSecondaryKey
        {
            get;
            set;
        }
        /// <summary>
        /// Represents quick load primary key.
        /// </summary>
        internal KeyCode quickLoadPrimaryKey
        {
            get;
            set;
        }
        /// <summary>
        /// Represents quick load secondary key.
        /// </summary>
        internal KeyCode quickLoadSecondaryKey
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the game save and reloads mods.
        /// </summary>
        private void quickLoad()
        {
            // Written, 09.03.2019

            time = Time.time;
            if (this.requestedQuickLoad)
                ModConsole.Print("[QuickSaveLoad] - requested load");
            ModLoader.MSCUnloaderInstance.reset = false;
            ModLoader.MSCUnloaderInstance.MSCLoaderReset();
            time = Time.time - time;
            ModConsole.Print(String.Format("[QuickSaveLoad] - loaded in {0}ms", time));            
        }
        /// <summary>
        /// Saves the game and reloads mods.
        /// </summary>
        private void quickSave()
        {
            // Written, 10.03.2019
            
            time = Time.time;
            ModConsole.Print("[QuickSaveLoad] - requested save");
            PlayMakerFSM.BroadcastEvent("SAVEGAME");
            time = Time.time - time;
            ModConsole.Print(String.Format("[QuickSaveLoad] - saved in {0}ms", time));
            this.quickLoad();
        }
        /// <summary>
        /// Occurs on gameobject start.
        /// </summary>
        private void Start()
        {
            // Written, 09.03.2019

            this.quickSavePrimaryKey = KeyCode.F5;
            this.quickSaveSecondaryKey = KeyCode.None;
            this.quickLoadPrimaryKey = KeyCode.F6;
            this.quickLoadSecondaryKey = KeyCode.None;

            ModConsole.Print(String.Format("{0}: Started", nameof(QuickSaveLoadMono)));
        }
        /// <summary>
        /// Occurs every frame.
        /// </summary>
        private void Update()
        {
            // Written, 09.03.2019

            if (Input.GetKeyDown(quickSavePrimaryKey) || Input.GetKeyDown(quickSaveSecondaryKey))
            {
                this.requestedQuickSave = true;
            }
            else
            if (Input.GetKeyDown(quickLoadPrimaryKey) || Input.GetKeyDown(quickLoadSecondaryKey))
            {
                this.requestedQuickLoad = true;
            }
            if (this.requestedQuickSave)
            {

                this.quickSave();
                this.requestedQuickSave = false;
            }
            else
            {
                if (this.requestedQuickLoad)
                {
                    this.quickLoad();
                    this.requestedQuickLoad = false;
                }
            }
        }
    }
}
