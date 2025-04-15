using System.Collections.Generic;
using DanMotor.Common;

namespace DanMotor.DL
{
    public static class MotorDataStore
    {
        public static Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>> InitializeData()
        {
            return new Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>
            {
                { "Honda", new Dictionary<string, Dictionary<string, List<string>>>
                    {
                        { "Click 125", CreateConceptDict() },
                        { "Sniper 155", CreateConceptDict() }
                    }
                },
                { "Yamaha", new Dictionary<string, Dictionary<string, List<string>>>
                    {
                        { "Mio 125", CreateConceptDict() },
                        { "Raider 150", CreateConceptDict() }
                    }
                }
            };
        }

        private static Dictionary<string, List<string>> CreateConceptDict()
        {
            var dict = new Dictionary<string, List<string>>();
            foreach (var concept in MotorData.Concepts)
            {
                dict[concept] = new List<string>();
            }
            return dict;
        }
    }
}
