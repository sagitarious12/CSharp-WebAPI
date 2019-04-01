using System;
namespace _Logger
{

  class StringLog
  {

    public void LogsOnSingleLine(string[] args, string seperation, ConsoleColor color)
    {
      Console.ForegroundColor = color;
      string content = messageContent(args, seperation);
      Console.WriteLine(content);
      Console.WriteLine("");
      Console.ResetColor();
    }

    public void LogsOnMultiLine(string[] args, string seperation, ConsoleColor color)
    {
      Console.ForegroundColor = color;
      foreach (string s in args)
      {
        Console.WriteLine(s);
      }
      Console.WriteLine("");
      Console.ResetColor();
    }

    private string messageContent(string[] args, string seperation)
    {
      string content = "";
      if (seperation != "")
      {
        for (int i = 0; i < args.Length; i++)
        {
          if (i == 0)
          {
            content += args[i];
          }
          else if (i + 1 != args.Length)
          {
            content += " " + args[i] + seperation;
          }
          else
          {
            content += " " + args[i];
          }
        }
      }
      else content = string.Join(" ", args);
      return content;
    }
  }

}