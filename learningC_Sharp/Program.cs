using System;
using System.Collections.Generic;
using System.Linq;

namespace learningC_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiating the generator object
            saveVars save = new saveVars();
            save.getSaveVariable();
        }
    }
    class randomNameGen
    {
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public string generateString (int charCount)
        {
            char[] nameComponents = new char[charCount];
            for(int i = 0; i < charCount; i++)
            {
                nameComponents[i] = Convert.ToChar(RandomNumber(66, 91));
            }
            string newVarName = new string(nameComponents);
            return newVarName;
        }
    }
    class saveVars
    {
        //creates a new expandable list for string names
        public Dictionary<string, string> nameDict = new Dictionary<string, string>();
        public Dictionary<string, int> intDict = new Dictionary<string, int>();
        public Dictionary<string, bool> boolDict = new Dictionary<string, bool>();
        public Dictionary<string, string> stringDict = new Dictionary<string, string>();
        public Dictionary<string, double> doubleDict = new Dictionary<string, double>();
        int saveInList = 0;
        
        public void getSaveVariable()
        {
            while (true)
            {
                Console.WriteLine("Would you like to create or read a variable?");
                string inputDecision = Console.ReadLine();
                if (inputDecision == "create")
                {
                    getInputSave();
                }
                else if (inputDecision == "read")
                {
                    getValue();
                } else
                {
                    Console.WriteLine("please enter \"create\" or \"read\"");
                }
            }
        }
        private void getValue()
        {
            Console.WriteLine("What is the access key of your variable?");
            string accessKey = Console.ReadLine();
            string varDictKey;
            if(nameDict.ContainsKey(accessKey))
            {
                varDictKey = nameDict[accessKey];
                if(intDict.ContainsKey(varDictKey))
                {
                    Console.WriteLine("Variable successfully fetched: " + varDictKey + " was found in the integer dictionary equal to: " + intDict[varDictKey]);
                } else if (boolDict.ContainsKey(varDictKey))
                {
                    Console.WriteLine("Variable successfully fetched: " + varDictKey + " was found in the boolean dictionary equal to: " + boolDict[varDictKey]);
                }
                else if (stringDict.ContainsKey(varDictKey))
                {
                    Console.WriteLine("Variable successfully fetched: " + varDictKey + " was found in the string dictionary equal to: " + stringDict[varDictKey]);
                }
                else if (doubleDict.ContainsKey(varDictKey))
                {
                    Console.WriteLine("Variable successfully fetched: " + varDictKey + " was found in the double dictionary equal to: " + doubleDict[varDictKey]);
                }
                else
                {
                    Console.WriteLine("Error: failed to fetch value");
                }
            } else
            {
                Console.WriteLine("Please enter a valid access key");
            }
        }
        private void getInputSave()
        {
            //while (true)
            //{
                Console.WriteLine("What data type is the variable?");
                saveVarsInList(Console.ReadLine());

            //}
        }
        private void saveVarsInList (string type)
        {
            randomNameGen generator = new randomNameGen();
            
            if (type == "int")
            {
                Console.WriteLine("What is the value of the variable?");
                string userValueInput = Console.ReadLine();
                string intName = generator.generateString(6);
                overloadSave(intName, Convert.ToInt32(userValueInput));
                Console.WriteLine("Your new integer is called " + intName + " and is equal to " + userValueInput + " and is access number " + saveInList + " in the name list.");
                nameDict.Add(Convert.ToString(saveInList), intName);
                intName = "";
            } else if (type == "boolean")
            {
                Console.WriteLine("What is the value of the variable?");
                string userValueInputB = Console.ReadLine();
                string boolName = generator.generateString(6);
                overloadSave(boolName, Convert.ToBoolean(userValueInputB));
                Console.WriteLine("Your new boolean is called " + boolName + " and is " + userValueInputB + " and is access number " + saveInList + " in the name list.");
                nameDict.Add(Convert.ToString(saveInList), boolName);
                boolName = "";
            } else if (type == "float")
            {
                Console.WriteLine("What is the value of the variable?");
                string userValueInputF = Console.ReadLine();
                string floatName = generator.generateString(6);
                overloadSave(floatName, Convert.ToDouble(userValueInputF));
                Console.WriteLine("Your new double is called " + floatName + " and is equal to " + userValueInputF + " and is access number " + saveInList + " in the name list.");
                nameDict.Add(Convert.ToString(saveInList), floatName);
                floatName = "";
            } else if (type == "string")
            {
                Console.WriteLine("What is the value of the variable?");
                string userValueInputS = Console.ReadLine();
                string stringName = generator.generateString(6);
                overloadSave(stringName, Convert.ToString(userValueInputS));
                Console.WriteLine("Your new string is called " + stringName + " and is equal to " + userValueInputS + " and is access number " + saveInList + " in the name list.");
                nameDict.Add(Convert.ToString(saveInList), stringName);
                stringName = "";
            } else
            {
                Console.WriteLine("Please enter an accepted variable assigner: int, boolean, float, or string");
                getInputSave();
            }
            saveInList++;
        }
        private void overloadSave (string name, int input)
        {
            intDict.Add(name, input);
        }
        private void overloadSave (string name, string input)
        {
            stringDict.Add(name, input);
        }
        private void overloadSave (string name, double input)
        {
            doubleDict.Add(name, input);
        }
        private void overloadSave (string name, bool input)
        {
            boolDict.Add(name, input);
        }
    }
}