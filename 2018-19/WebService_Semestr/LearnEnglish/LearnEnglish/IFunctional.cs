using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish
{
    interface IFunctional
    {
        List<string> GetTask();
        void CheckAnswCorrctness(string str);
        string GetNextQuest(List<string> questions);

        // для случаев, что будет несколько вариантов ответа, то int отвечает на правильность
        List<Tuple<string, int>> GetCurrConfiguration();
        //если вариант один, то использовать не нужно
    }
}
