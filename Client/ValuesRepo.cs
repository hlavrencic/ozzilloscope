using System.Collections.Generic;
using System.Linq;

namespace Scopeduino
{
    public class ValuesRepo
    {
        private List<IList<double>> bdd;
        private IList<double> currentList;
        private int groupCount;

        public ValuesRepo()
        {
            bdd = new List<IList<double>>();
            currentList = new List<double>();
            groupCount = 100;
        }

        public int BddCount => bdd.Count;

        public void SetGroupCount(int cant)
        {
            groupCount = cant;
        }

        public IList<double> Add(double values)
        {
            IList<double> rta = null;

            if(currentList.Count >= groupCount)
            {
                bdd.Insert(0, currentList);
                if(bdd.Count > 100)
                {
                    bdd.RemoveAt(100);
                }

                rta = currentList;
                currentList = new List<double>();
            }

            currentList.Insert(0, values);

            return rta;
        }

        public IList<double> Get(int pos)
        {
            return bdd.ElementAt(pos);
        }
    }
}
