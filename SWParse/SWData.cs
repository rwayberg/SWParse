using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWParse
{
    public class SWData
    {
        public class S3Data
        {
            public int gvalue { get; set; }
            public bool enchanted { get; set; }
        }

        public class S2Data
        {
            public int gvalue { get; set; }
            public bool enchanted { get; set; }
        }

        public class S1Data
        {
            public int gvalue { get; set; }
            public bool enchanted { get; set; }
        }

        public class S4Data
        {
            public int? gvalue { get; set; }
            public bool? enchanted { get; set; }
        }

        public class Rune
        {
            public object sub_hpp { get; set; }
            public string set { get; set; }
            public int grade { get; set; }
            public object sub_hpf { get; set; }
            public string sub_acc { get; set; }    //Changed from object to string
            public int i_v { get; set; }
            public string i_t { get; set; }
            public int id { get; set; }
            public S3Data s3_data { get; set; }
            public object sub_atkf { get; set; }
            public int slot { get; set; }
            public object sub_crate { get; set; }
            public object sub_spd { get; set; }
            public int s2_v { get; set; }
            public string s2_t { get; set; }
            public string s4_t { get; set; }
            public int s4_v { get; set; }
            public int monster { get; set; }
            public int s1_v { get; set; }
            public S2Data s2_data { get; set; }
            public int s3_v { get; set; }
            public object sub_atkp { get; set; }
            public object sub_res { get; set; }
            public S1Data s1_data { get; set; }
            public int locked { get; set; }
            public int level { get; set; }
            public object sub_deff { get; set; }
            public string monster_n { get; set; }
            public object sub_cdmg { get; set; }
            public string s3_t { get; set; }
            public object unique_id { get; set; }
            public S4Data s4_data { get; set; }
            public string s1_t { get; set; }
            public int m_v { get; set; }
            public object sub_defp { get; set; }
            public string m_t { get; set; }
        }

        public class DecoList
        {
            public int pos_x { get; set; }
            public int pos_y { get; set; }
            public int deco_id { get; set; }
            public int level { get; set; }
            public int wizard_id { get; set; }
            public int island_id { get; set; }
            public int master_id { get; set; }
        }

        public class Mon
        {
            public int b_spd { get; set; }
            public int b_atk { get; set; }
            public int b_acc { get; set; }
            public int b_crate { get; set; }
            public int id { get; set; }
            public int b_def { get; set; }
            public string name { get; set; }
            public int level { get; set; }
            public int b_cdmg { get; set; }
            public object unit_id { get; set; }
            public int stars { get; set; }
            public string attribute { get; set; }
            public int master_id { get; set; }
            public int b_res { get; set; }
            public int b_hp { get; set; }
        }

        public class RootObject
        {
            private List<Rune> m_runes;
            public List<Rune> runes { get { return m_runes; } set { this.m_runes = value; } }
            public List<DecoList> deco_list { get; set; }
            public int wizard_id { get; set; }
            public int tvalue { get; set; }
            public List<Mon> mons { get; set; }
            public List<object> crafts { get; set; }
            public List<object> savedBuilds { get; set; }

            public RootObject()
            {

            }
        }
    }
}
