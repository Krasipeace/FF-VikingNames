using HarmonyLib;
using UnityEngine;
using MelonLoader;

using System.Collections.Generic;

[assembly: MelonInfo(typeof(VikingNames.VikingNames), "Viking Names", "1.0.0", "Krasipeace")]
[assembly: MelonGame("Crate Entertainment", "Farthest Frontier")]

namespace VikingNames
{
    public class VikingNames : MelonMod
    {
        public static List<string> MaleVikingNames = new List<string>()
        {
            "Agnar", "Alaric", "Alfgeir", "Alvi", "Arinbjorn", "Arnkell", "Arnor", "Asbjorn", "Askell", "Astrid",
            "Audun", "Bard", "Bersi", "Bjarni", "Bjorn", "Boke", "Bolverk", "Brand", "Brokkr", "Canute",
            "Dag", "Einar", "Erik", "Eyolf", "Eyvindr", "Finn", "Floki", "Folke", "Gardar", "Geirmund",
            "Geri", "Gisli", "Gorm", "Grim", "Gunnar", "Halfdan", "Hallbjorn", "Hallvard", "Hamund", "Harald",
            "Havard", "Hedin", "Helgi", "Herbjorn", "Herleif", "Hermod", "Hervor", "Hildir", "Holmgeir", "Hrolf",
            "Hrut", "Ivar", "Jarl", "Joar", "Jon", "Kalf", "Ketil", "Kjartan", "Kolbein", "Kori",
            "Lager", "Leif", "Lodin", "Magni", "Mar", "Mord", "Narfi", "Neri", "Odd", "Olaf",
            "Orm", "Osvald", "Ottar", "Ragnar", "Randi", "Refil", "Reidar", "Rognvald", "Rolf", "Snorri",
            "Solvi", "Starkad", "Stein", "Steinar", "Stig", "Styrbjorn", "Surt", "Sven", "Thor", "Thorbjorn",
            "Thord", "Thorfinn", "Thorgeir", "Thorleif", "Thorstein", "Torfi", "Tryggvi", "Ulf", "Valdemar", "Vidar"
        };

        public static List<string> FemaleVikingNames = new List<string>()
        {
            "Aasa", "Adils", "Aesa", "Agneta", "Alfhild", "Alva", "Arnbjorg", "Arndis", "Astrid", "Aud",
            "Audhild", "Bergdis", "Bergljot", "Bera", "Birgit", "Bjarnhild", "Bodil", "Borghild", "Brynhild", "Daga",
            "Dagmar", "Disa", "Edda", "Eerika", "Eevi", "Eira", "Elina", "Elsi", "Embla", "Estrid",
            "Frida", "Gerd", "Groa", "Gudrid", "Gunhild", "Hallbera", "Hallfrid", "Hallgerd", "Halldora", "Hannele",
            "Harpa", "Heda", "Helga", "Herborg", "Herdis", "Hervor", "Hildi", "Hildigunn", "Holmfridur", "Hrefna",
            "Hulda", "Ingaborg", "Inga", "Ingeborg", "Ingrid", "Iselin", "Jorunn", "Jutta", "Kara", "Karna",
            "Katla", "Kjerstin", "Kristin", "Laufey", "Liv", "Lova", "Magnhild", "Malla", "Maret", "Marit",
            "Marna", "Mette", "Nanna", "Nilla", "Olga", "Oydis", "Ragnhild", "Ragna", "Randi", "Rannveig",
            "Reeta", "Rikka", "Runa", "Saga", "Sanna", "Signe", "Signy", "Sirkka", "Siv", "Solveig",
            "Steinvor", "Svanhild", "Swanhild", "Thora", "Thordis", "Thorunn", "Thyra", "Tove", "Unn", "Ylva"
        };

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Viking Names mod loaded!");
        }

        [HarmonyPatch(typeof(VillagerNameManager), "GetRandomName")]
        public class Patch_VillagerNameManager_GetRandomName
        {
            protected static bool Prefix(bool isMale, ref string vikingName)
            {
                if (isMale && MaleVikingNames.Count > 0)
                {
                    vikingName = MaleVikingNames[Random.Range(0, MaleVikingNames.Count)];

                    return false; 
                }

                if (!isMale && FemaleVikingNames.Count > 0)
                {
                    vikingName = FemaleVikingNames[Random.Range(0, FemaleVikingNames.Count)];

                    return false; 
                }

                return true;
            }
        }
    }
}