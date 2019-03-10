using UnityEngine;
using MSCLoader;

namespace  TommoJProductions.QuickSaveLoad
{
    /// <summary>
    /// Represents quick save and load functions
    /// </summary>
    internal class QuickSaveLoadMono : MonoBehaviour
    {
        // Written, 09.03.2019

        #region Properties

        /// <summary>
        /// Represents if quick load has been requested by the player.
        /// </summary>
        private bool requestedQuickLoad
        {
            get;
            set;
        }
        /// <summary>
        /// Represents if quick save has been requested by the player.
        /// </summary>
        private bool requestedQuickSave
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
            
            if (this.requestedQuickLoad)
                ModConsole.Print("<color=grey><b>[QuickSaveLoad]</b> - player requested to quickload</color>");
            ModLoader.MSCUnloaderInstance.reset = false;
            ModLoader.MSCUnloaderInstance.MSCLoaderReset();          
        }
        /// <summary>
        /// Saves the game and reloads mods.
        /// </summary>
        private void quickSave()
        {
            // Written, 10.03.2019
                       
            ModConsole.Print("<color=grey><b>[QuickSaveLoad]</b> - player requested to quicksave</color>");
            PlayMakerFSM.BroadcastEvent("SAVEGAME");
            this.quickLoad();
        }
        /// <summary>
        /// Occurs every frame.
        /// </summary>
        private void Update()
        {
            // Written, 09.03.2019

            if (this.requestedQuickSave)
            {
                this.quickSave();
                //this.requestedQuickSave = false;
            }
            else
            {
                if (this.requestedQuickLoad)
                {
                    this.quickLoad();
                }
            }
            if (cInput.GetKeyDown("quicksave"))
            {
                this.requestedQuickSave = true;
            }
            if (cInput.GetKeyDown("quickload"))
            {
                this.requestedQuickLoad = true;
            }            
        }
        /// <summary>
        /// Standard Unity <see cref="MonoBehaviour"/> method. GUI stuff goes here..
        /// </summary>
        private void OnGUI()
        {
            // Written, 10.03.2019

            string _message = null;

            if (this.requestedQuickSave)
            {
                // send quicksaving feedback to player
                _message = "Quicksaving...";
            }
            else
            {
                if (this.requestedQuickLoad)
                {
                    // send quicksaving feedback to player
                    _message = "Quickloading...";
                }
            }
            _message = "<color=white>" + _message + "</color>";
            if (_message != null)
            GUI.Label(new Rect(5, 5, 100, 25), _message, new GUIStyle() { fontSize = 18 });
        }

        #endregion
    }
}
