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
        public string Layer { get; set; }
        public string BodyPart { get; set; }
        public string Gender { get; set; }
        public string AgeGroup { get; set; }
        public string Mood { get; set; }
        public string Occasion { get; set; }
        public string Style { get; set; }
        public string Season { get; set; }
        public string Weather { get; set; }


        public Outfit(int id, string name, string layer, string bodyPart, string gender, string ageGroup, string mood, string occasion, string style, string season, string weather)
        {
            Id = id;
            Name = name;
            Layer = layer;
            BodyPart = bodyPart;
            Gender = gender;
            AgeGroup = ageGroup;
            Mood = mood;
            Occasion = occasion;
            Style = style;
            Season = season;
            Weather = weather;
        }

        public override string ToString()
        {
            return $"{Name} \n(Слой: {Layer}\nПол: {Gender}\nВозрастная категория: {AgeGroup}\nНастроение: {Mood}\nНазначение: {Occasion}\nСтль: {Style}\nВремя года: {Season}\nПогода: {Weather})";
        }
    }
}
