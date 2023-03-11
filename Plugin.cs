using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using HarmonyLib.Tools;
using System.Linq;
using static ParameterItemDataMaterial;
using static uConstructionPanelMaterial;

namespace MaterialWorld;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInProcess("Digimon World Next Order.exe")]
public class Plugin : BasePlugin
{
    public static ManualLogSource logger;

    public static Plugin Instance { get; private set; }
    public override void Load()
    {
        HarmonyFileLog.Enabled = true;
        // Plugin startup logic
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        Harmony.CreateAndPatchAll(typeof(Patches));
        logger = Log;
        
    }
    class Patches
    {
        [HarmonyPatch(typeof(uConstructionPanelMaterial), nameof(uConstructionPanelMaterial.Update))]
        [HarmonyPostfix]
        static void uConstructionPanelMaterial_Update_Postfix(uConstructionPanelMaterial __instance)
        {
            if (PadManager.IsRepeat(PadManager.BUTTON.srUp))
            {
                MaterialData materialData = StorageData.m_materialData.ToArray().First(data => data.m_id == __instance.m_materialContents[__instance.m_materialContentCursor.index].id);
                materialData.AddMaterial(1);
                __instance.m_materialNums[__instance.m_materialContentCursor.index].SetNum(materialData.m_material_num);
                //HarmonyFileLog.Writer.WriteLine(
                //logger.LogMessage(Language.GetString(materialData.m_id) + ": " + materialData.m_material_num);
                
            }
            else if (PadManager.IsRepeat(PadManager.BUTTON.srDown))
            {
                MaterialData materialData = StorageData.m_materialData.ToArray().First(data => data.m_id == __instance.m_materialContents[__instance.m_materialContentCursor.index].id);
                materialData.AddMaterial(-1);
                __instance.m_materialNums[__instance.m_materialContentCursor.index].SetNum(materialData.m_material_num);
                //HarmonyFileLog.Writer.WriteLine(
                //logger.LogMessage(Language.GetString(materialData.m_id) + ": " + materialData.m_material_num);

            }
            else if (PadManager.IsRepeat(PadManager.BUTTON.bStart))
            {
                logger.LogMessage("Gave All Materials");
                StorageData.m_materialData.ToArray().Do(data => data.m_is_get = true);
                __instance.UpdatePanelAndSetCursorIndex(__instance.m_materialKindCursor.index, __instance.m_materialContentCursor.index);
            }
            else if (PadManager.IsRepeat(PadManager.BUTTON.bSelect))
            {
                logger.LogMessage("Took All Materials");
                StorageData.m_materialData.ToArray().Do(data => { if (data.m_material_num == 0) data.m_is_get = false; });
                __instance.UpdatePanelAndSetCursorIndex(__instance.m_materialKindCursor.index, __instance.m_materialContentCursor.index);
            }

        }
    }
}
