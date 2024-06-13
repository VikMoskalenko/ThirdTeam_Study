using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTeam_Study.Managers
{
    public class InputManager
    {
        public static void UserInput(string Message, Action<string> setInput)
        {
            bool enterError;
            do
            {
                enterError = false;
                try
                {
                    OutputManager.Write(Message);
                    string input = Console.ReadLine();
                    if (input != null)
                    {
                        setInput(input);
                    }
                }
                catch (ArgumentException ex)
                {
                    OutputManager.Write(ex.Message);
                    enterError = true;

                }
            } while (enterError);
        }
    }
}
