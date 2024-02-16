using UnityEngine;
using ModSettings;
using MelonLoader;

namespace LookDontTorch
{
    internal class SomeSettings : JsonModSettings
    {       
        [Section("General")]

        [Name("Torch")]
        [Description("Disable extinguishing of torch on mouseclick")]
        public bool disableTorch = true;

        [Name("Lantern")]
        [Description("Disable extinguishing of lantern on mouseclick")]
        public bool disableLantern = true;

        protected override void OnConfirm()
        {
            base.OnConfirm();
        }
    }

    internal static class Settings
    {
        public static SomeSettings options;

        public static void OnLoad()
        {
            options = new SomeSettings();
            options.AddToModSettings("Look - Don't Torch");
        }
    }
}
