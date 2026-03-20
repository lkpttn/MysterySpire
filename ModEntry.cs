using HarmonyLib;
using MegaCrit.Sts2.Core.Modding;

namespace MysterySpire;

[ModInitializer("Initialize")]
public class ModEntry
{
    public static void Initialize()
    {
        var harmony = new Harmony("com.locksmith.mysteryspire");
        harmony.PatchAll();
    }
}
