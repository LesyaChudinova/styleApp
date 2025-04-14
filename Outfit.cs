using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class Outfit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Weather { get; set; }
        public string Occasion { get; set; }
        public string Style { get; set; }

        public Outfit(int id, string name, string weather, string occasion, string style)
        {
            Id = id;
            Name = name;
            Weather = weather;
            Occasion = occasion;
            Style = style;
        }

        public override string ToString()
        {
            return $"{Name} (Погода: {Weather}, Мероприятие: {Occasion}, Стиль: {Style})";
        }
    }
}
