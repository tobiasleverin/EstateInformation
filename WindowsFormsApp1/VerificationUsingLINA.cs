using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SeleniumTests;

namespace SequenceVerification
{
    public class VerificationUsingLINA : ISequenceVerification
    {
        private List<string> inputSequence;
        private List<string> resultList;
        const string winLineBreakChars = "\r\n";

        public void prepareSequence(StringBuilder input)
        {
            string[] lineBreaks = new string[1] { winLineBreakChars };
            List<string> list = input.ToString().Split(lineBreaks, StringSplitOptions.None).ToList();
            inputSequence = list;
        }

        public void executeSequence()
        {
            UnitTest1 testClass = new UnitTest1();
            try
            {
                testClass.UploadTestData(inputSequence);
                testClass.SetupTest();
                testClass.TestMethodLogin();

                int sequenceIndex = 0;
                int iterationIndex = 0;
                int iterationSize = 10;

                while (sequenceIndex < inputSequence.Count)
                {
                    iterationIndex = 0;
                    do
                    {
                        testClass.TestMethodVerifyByIndex();
                        Thread.Sleep(1 * 1000); //Wait for 3 secs

                        //Increment indexes
                        sequenceIndex++;
                        testClass.SetInputSequenceIndex(sequenceIndex);
                        iterationIndex++;

                        //End of inputSequence
                        if (sequenceIndex == inputSequence.Count) break;

                    } while (iterationIndex < iterationSize);

                    testClass.TestMethodToIncementSession();
                    Thread.Sleep(3 * 1000); //Wait for 30 secs
                }//Repeat iteration
            }
            finally
            {
                resultList = testClass.GetTestResult();
                testClass.TestMethodLogout();
                testClass.TeardownTest();
            }
        }//End executeSequence

        public StringBuilder getResult(string format)
        {
            string stringResult = string.Join(winLineBreakChars, resultList);
            return new StringBuilder(stringResult);
        }
    }
}
