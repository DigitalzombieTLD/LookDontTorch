using MelonLoader;
using UnityEngine;
using Il2CppInterop;
using Il2CppInterop.Runtime.Injection; 
using System.Collections;
using System.Collections.Generic;
using Il2Cpp;
using Il2CppTLD.Gear;

namespace LookDontTorch
{
    [HarmonyLib.HarmonyPatch(typeof(TorchItem), "ExtinguishDelayed")]
    public class TorchItemPatch
    {
        public static bool Prefix(TorchItem __instance)
        {
            if (Settings.options.disableTorch)
            {
                return false;
            }
            else
            { 
                return true; 
            }
            
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(InputManager), "ExecuteHolsterAction")]
    public class HolsterPatchTorch
    {
        public static bool Prefix(InputManager __instance)
        {
            if (Settings.options.disableTorch && GameManager.GetPlayerManagerComponent().m_ItemInHands && GameManager.GetPlayerManagerComponent().m_ItemInHands.m_TorchItem)
            {
                TorchItem holdingTorch = GameManager.GetPlayerManagerComponent().m_ItemInHands.m_TorchItem;
             
                if (holdingTorch.IsBurning())
                {
                    InterfaceManager.GetPanel<Panel_HUD>().StartItemProgressBar(holdingTorch.m_ExtinguishTime, Localization.Get("GAMEPLAY_Extinguishing"), holdingTorch.GetGearItem(), new Action(holdingTorch.ExtinguishAfterDelayStarted));
                    return false;
                }                            
            }
            return true;
        }
    }


    [HarmonyLib.HarmonyPatch(typeof(KeroseneLampItem), "Toggle")]
    public class LampItemPatch2
    {
        public static bool Prefix(KeroseneLampItem __instance)
        {
            if (__instance.m_On && Settings.options.disableLantern)
            {
                return false;
            }
            else
            {
                return true;
            }            
        }
    }
}