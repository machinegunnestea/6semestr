using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WindowsFormsApp1.Entities;
using Newtonsoft.Json;
using WindowsFormsApp1.Interface;

namespace WindowsFormsApp1.Repositories 
{
    public class AligRep : IAligatorRepository
    {
        public const string JsonName = @"D:\uni\6sem\ИГИ\def1\WindowsFormsApp1\alig.json";

        public List<Aligator> GetAll()
        {
            List<Aligator> list = new List<Aligator>();
            using (StreamReader file = File.OpenText(JsonName))
            {
                JsonSerializer serializer = new JsonSerializer();
                list = (List<Aligator>)serializer.Deserialize(file, typeof(List<Aligator>));
            }
            return list;
        }
        public bool Create(Aligator item)
        {
            try
            {
                List<Aligator> aligators = GetAll().ToList();
                aligators.Add(item);
                var json = JsonConvert.SerializeObject(aligators);
                File.WriteAllText(JsonName, json);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(string item)
        {
            try
            {
                List<Aligator> aligators = GetAll().ToList();
                var del = aligators.FindIndex(x => x.Name == item);
                aligators.RemoveAt(del);
                var json = JsonConvert.SerializeObject(aligators);
                File.WriteAllText(JsonName, json);
                return true;
            }
            catch
            {
                throw;
            }
        }
        public Aligator FindByWeight(int weight)
        {
            return GetAll().FirstOrDefault(x => x.Weight == weight);
        }
        public void FindByHeight(int weight)
        {
            List<Aligator> lists = GetAll().ToList();
            var groupByHeight = from list in lists
                                group list by list.Height into newGroup
                                select new { 
                                    ID = newGroup.Key,
                                    Average = newGroup.Average(x=>x.Weight)
                                };
        }
    }
}

