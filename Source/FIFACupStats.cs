using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Codenation.Challenge
{
    public class FIFACupStats
    {
        public string CSVFilePath { get; set; } = "data.csv";

        public Encoding CSVEncoding { get; set; } = Encoding.UTF8;

        int i = 1;

        List<string> lista = new List<string>();

        public int NationalityDistinctCount()
        {
            var jogadores = File.ReadAllLines(CSVFilePath).Select(a => a.Split(',')).ToList();

            for (int j = 1; j < jogadores.Count(); j++)
            {
                var nacionalidade = jogadores.ElementAt(i).GetValue(14);
                if (!lista.Contains(nacionalidade))
                    lista.Add(nacionalidade.ToString());
                i++;

            }

            return lista.Count();

        }

        public int ClubDistinctCount()
        {
            var jogadores = File.ReadAllLines(CSVFilePath).Select(a => a.Split(',')).Where(x => x[3] != "").ToList();
            for (int j = 1; j < jogadores.Count; j++)
            {
                var clubes = jogadores.ElementAt(i).GetValue(3);
                if (!lista.Contains(clubes))
                    lista.Add(clubes.ToString());
                i++;
            }

            return lista.Count;
        }

        public List<string> First20Players()
        {

            var jogadores = File.ReadAllLines(CSVFilePath).Select(a => a.Split(',')).ToList();
            for (int j = 1; j < jogadores.Count(); j++)
            {
                if (lista.Count() > 19)
                    break;
                lista.Add(jogadores.ElementAt(i).GetValue(2).ToString());
                i++;

            }

            return lista;

        }

        public List<string> Top10PlayersByReleaseClause()
        {

            var jogadores = File.ReadAllLines(CSVFilePath).Select(a => a.Split(',')).Where(x => x[18] != "").Skip(1).OrderByDescending(x => Convert.ToDouble(x[18].Replace(".",","))).Take(10).ToList();
            for (int i = 0; i < jogadores.Count; i++)
            {
                lista.Add(jogadores.ElementAt(i).GetValue(2).ToString());
            }

            return lista;
        }

        public List<string> Top10PlayersByAge()
        {    
            var jogadores = File.ReadAllLines(CSVFilePath).Select(a => a.Split(',')).Where(x => x[8] != "").Skip(1).OrderBy(x => x[8]).ThenBy(x => x[17]).Take(10).ToList();
            for (int i = 0; i < jogadores.Count; i++)
            {
                lista.Add(jogadores.ElementAt(i).GetValue(2).ToString());
            }
            
            return lista;
        }

        public Dictionary<int, int> AgeCountMap()
        {         
            Dictionary<int, int> idadeQuantidade = new Dictionary<int, int>();
            var jogadores2 = File.ReadAllLines(CSVFilePath).Select(a => a.Split(',')).Where(x => x[6] != "").Skip(1).GroupBy(x => x[6]).ToList();
            for (int i = 0; i < jogadores2.Count; i++)
            {
                idadeQuantidade.Add(Convert.ToInt32(jogadores2.ElementAt(i).Key), jogadores2.ElementAt(i).Count());
            }
            return idadeQuantidade;
        }
    }
}
