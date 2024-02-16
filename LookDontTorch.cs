using MelonLoader;
using UnityEngine;
using Il2CppInterop;
using Il2CppInterop.Runtime.Injection; 
using System.Collections;


namespace LookDontTorch
{
	public class LookDontTorchMain : MelonMod
	{
		public override void OnInitializeMelon()
		{
            Settings.OnLoad();
        }
    }
}