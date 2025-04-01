using System;
using System.Collections.Generic;

namespace DanMotor
{
    public class MotorService
    {
        private readonly Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>> motorConcepts;

        public MotorService()
        {
            // Initialize the motor concepts with some data
            motorConcepts = new Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>
            {
                { "Honda", new Dictionary<string, Dictionary<string, List<string>>>
                    {
                        { "Click 125", new Dictionary<string, List<string>>
                            {
                                { "Malaysian", new List<string> { } },
                                { "Indonesian", new List<string> { } },
                                { "Thai", new List<string> { } }
                            }
                        },
                        { "Sniper 155", new Dictionary<string, List<string>>
                            {
                                { "Malaysian", new List<string> { } },
                                { "Indonesian", new List<string> { } },
                                { "Thai", new List<string> { } }
                            }
                        }
                    }
                },
                { "Yamaha", new Dictionary<string, Dictionary<string, List<string>>>
                    {
                        { "Mio 125", new Dictionary<string, List<string>>
                            {
                                { "Malaysian", new List<string> { } },
                                { "Indonesian", new List<string> { } },
                                { "Thai", new List<string> { } }
                            }
                        },
                        { "Raider 150", new Dictionary<string, List<string>>
                            {
                                { "Malaysian", new List<string> { } },
                                { "Indonesian", new List<string> { } },
                                { "Thai", new List<string> { } }
                            }
                        }
                    }
                }
            };
        }

        public List<string> GetModels(string brand)
        {
            return motorConcepts.ContainsKey(brand) ? new List<string>(motorConcepts[brand].Keys) : new List<string>();
        }

        public List<string> GetConcepts(string brand, string model)
        {
            return motorConcepts.ContainsKey(brand) && motorConcepts[brand].ContainsKey(model)
                ? new List<string>(motorConcepts[brand][model].Keys)
                : new List<string>();
        }

        public List<string> GetParts(string brand, string model, string concept)
        {
            return motorConcepts.ContainsKey(brand) && motorConcepts[brand].ContainsKey(model) && motorConcepts[brand][model].ContainsKey(concept)
                ? motorConcepts[brand][model][concept]
                : new List<string>();
        }

        public bool AddPart(string brand, string model, string concept, string part)
        {
            if (motorConcepts.ContainsKey(brand) && motorConcepts[brand].ContainsKey(model) && motorConcepts[brand][model].ContainsKey(concept))
            {
                motorConcepts[brand][model][concept].Add(part);
                return true;
            }
            return false;
        }

        public bool EditPart(string brand, string model, string concept, string oldPart, string newPart)
        {
            if (motorConcepts.ContainsKey(brand) && motorConcepts[brand].ContainsKey(model) && motorConcepts[brand][model].ContainsKey(concept))
            {
                var parts = motorConcepts[brand][model][concept];
                int index = parts.IndexOf(oldPart);
                if (index >= 0)
                {
                    parts[index] = newPart;
                    return true;
                }
            }
            return false;
        }

        public bool DeletePart(string brand, string model, string concept, string part)
        {
            if (motorConcepts.ContainsKey(brand) && motorConcepts[brand].ContainsKey(model) && motorConcepts[brand][model].ContainsKey(concept))
            {
                var parts = motorConcepts[brand][model][concept];
                return parts.Remove(part);
            }
            return false;
        }
    }
}
    