using MSCLoader;
using UnityEngine;

namespace TommoJProductions.QuickSaveLoad
{
    public class QuickSaveLoadMod : Mod
    {
        // Written, 10.03.2019

        #region Mod Properties

        public override string ID => "QuickSaveLoad";
        public override string Name => "Quick Save/Load";
        public override string Version => "1.1";
        public override string Author => "tommojphillips";

        #endregion

        #region Properties

        /// <summary>
        /// Represents the <see cref="QuickSaveLoadMono"/> instance.
        /// </summary>
        private QuickSaveLoadMono quickSaveLoadInstance;
        /// <summary>
        /// Represents the quicksave cinput name.
        /// </summary>
        public const string QUICKSAVE_CINPUT_NAME = "quicksave";
        /// <summary>
        /// Represents the quickload cinput name.
        /// </summary>
        public const string QUICKLOAD_CINPUT_NAME = "quickload";

        #endregion

        #region Mod Methods

        /// <summary>
        /// Occurs on mod load (Game load).
        /// </summary>
        public override void OnLoad()
        {
            // Written, 10.03.2019

            // Creating input data in cInput..
            cInput.SetKey(QUICKSAVE_CINPUT_NAME, "F5", "None");
            cInput.SetKey(QUICKLOAD_CINPUT_NAME, "F6", "None");
            GameObject quickSaveLoad = new GameObject(this.ID);
            // Removing experimental warning as you get this every time you reset MSCLoader (when quick save/load).
            if (!(bool)ModSettings_menu.expWarning.Value)
                ModSettings_menu.expWarning.Value = true;
            this.quickSaveLoadInstance = quickSaveLoad.AddComponent<QuickSaveLoadMono>(); // initializing quicksaveload instance.
            ModConsole.Print(string.Format("{0} v{1}: Loaded", this.Name, this.Version));
        }

        #endregion
    }
}
