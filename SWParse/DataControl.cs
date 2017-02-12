using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace SWParse
{
    public class DataControl
    {
        public String FileName { get; private set; }
        private SWData.RootObject optData;

        public DataControl(string File)
        {
            this.FileName = File;
            LoadData();
            
        }

        private void LoadData()
        {
            try
            {
                string fileString = File.ReadAllText(this.FileName);
                this.optData = JsonConvert.DeserializeObject<SWData.RootObject>(fileString);
                
            }
            catch(Exception ex)
            {   //TODO - new expection
                throw ex;
            }
        }

        public int GetRuneCount()
        {
            //return 0;
            return this.optData.runes.Count;
        }

        public List<string> GetMonsterList()
        {
            List<string> monList = new List<string>();
            foreach(SWData.Mon monster in this.optData.mons)
            {
                monList.Add(monster.name);
            }
            return monList;
        }

        public SWData.Mon GetMonster(string MonsterName)
        {
            //SWData.Mon monster = new SWData.Mon();
            return this.optData.mons.Find(x => x.name == MonsterName);
            
        }

        public List<SWData.Rune> GetMonsterRune(string MonsterName)
        {
            SWData.Mon monster = GetMonster(MonsterName);
            return this.optData.runes.FindAll(x => x.monster == monster.id);
        }

        public List<SWData.Rune> GetHighestAcc()
        {
            //List<SWData.Rune> sortAcc = this.optData.runes.OrderByDescending(x => x.sub_acc).ToList();
            //return sortAcc[0];
            List<SWData.Rune> sortAcc = this.optData.runes;
            sortAcc.OrderBy(x => int.Parse(x.sub_acc));
            return sortAcc;
            //return sortAcc[0];
        }

        public List<SWData.Rune> GetRunesInSlot(List<SWData.Rune> RuneList, int Slot)
        {
            if (RuneList.Count <= 0)
                return new List<SWData.Rune>();
            return RuneList.FindAll(x => x.slot == Slot);

        }

        public List<SWData.Rune> RuneSetList(List<SWData.Rune> RuneList)
        {
            List<SWData.Rune> runeset = new List<SWData.Rune>();
            if (RuneList.Count <= 0)
                return runeset;

            return runeset;
        }

        public List<SWData.Rune> SortedRuneList(List<SWData.Rune> RuneList)
        {
            List<SWData.Rune> sortset = new List<SWData.Rune>();
            if (RuneList.Count > 0)
            {
                SWData.Rune tempRune = new SWData.Rune();
                sortset.Add(RuneList.FirstOrDefault(x => x.slot == 1));
                sortset.Add(RuneList.FirstOrDefault(x => x.slot == 2));
                sortset.Add(RuneList.FirstOrDefault(x => x.slot == 3));
                sortset.Add(RuneList.FirstOrDefault(x => x.slot == 4));
                sortset.Add(RuneList.FirstOrDefault(x => x.slot == 5));
                sortset.Add(RuneList.FirstOrDefault(x => x.slot == 6));
            }
            return sortset;
        }
    }

  
}
