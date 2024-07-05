namespace ThirdTeam_Study.BusinessLayer.Managers
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
                    string? input = Console.ReadLine();
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
