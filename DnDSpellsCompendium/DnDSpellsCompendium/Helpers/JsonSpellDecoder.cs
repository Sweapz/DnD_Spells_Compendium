using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellsCompendium.Helpers
{
    public class JsonSpellDecoder
    {
        public static ObservableCollection<Spell> GetSpellsFromJsonFile(string path)
        {
            StreamReader streamReader = new StreamReader(path);

            JsonTextReader reader = new JsonTextReader(new StringReader(streamReader.ReadToEnd()));

            ObservableCollection<Spell> spells = new ObservableCollection<Spell>();


            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    Dictionary<string, string> spellDictionary = EncodeJsonDictionary(reader);

                    spells.Add(DictToSpell(spellDictionary));
                }
            }

            return spells;
        }

        private static Dictionary<string, string> EncodeJsonDictionary(JsonTextReader reader)
        {
            Dictionary<string, string> jsonEncoding = new Dictionary<string, string>();
            string key = null;

            while (reader.TokenType != JsonToken.EndObject)
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    key = reader.Value.ToString();
                }
                else if (reader.Value != null)
                {
                    jsonEncoding.Add(key, reader.Value.ToString());

                }
                reader.Read();

            }

            return jsonEncoding;
        }

        private static Spell DictToSpell(Dictionary<string, string> spellDictionary)
        {
            return spellDictionary.ContainsKey("HigherLevel") ?
                new Spell(
                    spellDictionary["Name"],
                    spellDictionary["Description"], 
                    spellDictionary["Level"],
                    spellDictionary["Range"],
                    spellDictionary["Components"],
                    spellDictionary["Duration"],
                    spellDictionary["CastingTime"],
                    GetSchoolEnum(spellDictionary["School"]),
                    GetSpellClasses(spellDictionary["Classes"]),
                    spellDictionary["HigherLevel"]) :
                new Spell(
                    spellDictionary["Name"],
                    spellDictionary["Description"],
                    spellDictionary["Level"],
                    spellDictionary["Range"],
                    spellDictionary["Components"],
                    spellDictionary["Duration"],
                    spellDictionary["CastingTime"],
                    GetSchoolEnum(spellDictionary["School"]),
                    GetSpellClasses(spellDictionary["Classes"]));
        }

        private static List<Class> GetSpellClasses(string v)
        {
            List<Class> classes = new List<Class>();

            foreach (Class dndClass in (Class[]) Enum.GetValues(typeof(Class)))
            {
                if (v.Contains(dndClass.ToString()))
                {
                    classes.Add(dndClass);
                }
            }

            return classes;
        }

        private static SpellSchool GetSchoolEnum(string v)
        {
            SpellSchool school;

            switch (v)
            {
                case "Abjuration":
                    school = SpellSchool.Abjuration;
                    break;
                case "Conjuration":
                    school = SpellSchool.Conjuration;
                    break;
                case "Divination":
                    school = SpellSchool.Divination;
                    break;
                case "Enchantment":
                    school = SpellSchool.Enchantment;
                    break;
                case "Evocation":
                    school = SpellSchool.Evocation;
                    break;
                case "Illusion":
                    school = SpellSchool.Illusion;
                    break;
                case "Necromancy":
                    school = SpellSchool.Necromancy;
                    break;
                case "Transmutation":
                    school = SpellSchool.Transmutation;
                    break;
                default:
                    throw new InvalidDataException();
            }

            return school;
        }
    }
}
