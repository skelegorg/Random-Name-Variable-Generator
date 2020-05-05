using System;
using System.Collections.Generic;

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
        public List<string> nameList = new List<string>();
        public Dictionary<string, int> intDict = new Dictionary<string, int>();
        public Dictionary<string, bool> boolDict = new Dictionary<string, bool>();
        public Dictionary<string, string> stringDict = new Dictionary<string, string>();
        public Dictionary<string, double> doubleDict = new Dictionary<string, double>();

        public void getSaveVariable()
        {
            getInputSave();
        }
        private void getInputSave()
        {
            while (true)
            {
                Console.WriteLine("What data type is the variable?");
                saveVarsInList(Console.ReadLine());

            }
        }
        private void saveVarsInList (string type)
        {
            randomNameGen generator = new randomNameGen();
            int saveInList = 0;
            if (type == "int")
            {
                Console.WriteLine("What is the value of the variable?");
                string userValueInput = Console.ReadLine();
                string intName = generator.generateString(6);
                overloadSave(intName, Convert.ToInt32(userValueInput));
                Console.WriteLine("Your new integer is called " + intName + " and is equal to " + userValueInput);
                nameList.Add(intName);
                intName = "";
            } else if (type == "boolean")
            {
                Console.WriteLine("What is the value of the variable?");
                string userValueInputB = Console.ReadLine();
                string boolName = generator.generateString(6);
                overloadSave(boolName, Convert.ToBoolean(userValueInputB));
                Console.WriteLine("Your new boolean is called " + boolName + " and is " + userValueInputB);
                boolName = "";
            } else if (type == "float")
            {
                Console.WriteLine("What is the value of the variable?");
                string userValueInputF = Console.ReadLine();
                string floatName = generator.generateString(6);
                overloadSave(floatName, Convert.ToDouble(userValueInputF));
                Console.WriteLine("Your new double is called " + floatName + " and is equal to " + userValueInputF);
                floatName = "";
            } else if (type == "string")
            {
                Console.WriteLine("What is the value of the variable?");
                string userValueInputS = Console.ReadLine();
                string stringName = generator.generateString(6);
                overloadSave(stringName, userValueInputS);
                Console.WriteLine("Your new string is called " + stringName + " and is equal to " + userValueInputS);
                stringName = "";
            } else
            {
                Console.WriteLine("Please enter an accepted variable assigner: int, boolean, float, or string");
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