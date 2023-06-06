using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using UnityEngine;

namespace CastleStory_SpeedOfUnits.Config
{
    struct Config
    {
        private Dictionary<UnitType, SpeedTable> _entries;
        public Dictionary<UnitType, SpeedTable> entries
        {
            get
            {
                return _entries;
            }
        }

        public Config(Dictionary<UnitType, SpeedTable> entries)
        {
            _entries = entries;
        }

        static public Config Parse(Table table)
        {
            Dictionary<UnitType, SpeedTable> entries = new Dictionary<UnitType, SpeedTable>();

            foreach (string type in Enum.GetNames(typeof(UnitType)))
            {
                try
                {
                    if (table.Get(type).IsNotNil())
                    {
                        Table typetable = table.Get(type).Table;
                        var speedTable = new SpeedTable(typetable.Get("walk").Number, typetable.Get("run").Number);
                        entries.Add((UnitType) Enum.Parse(typeof(UnitType), type), speedTable);
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                }
            }

            return new Config(entries);
        }
    }
}
