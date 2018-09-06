using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceVerification
{
    interface ISequenceVerification
    {
        void prepareSequence(StringBuilder input);


        void executeSequence();


        StringBuilder getResult(string format);
    }

}
