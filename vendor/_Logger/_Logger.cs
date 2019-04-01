using System;
using System.Runtime.CompilerServices;

namespace _Logger
{
  class Logger
  {
    private ConsoleColor color = ConsoleColor.White;
    private StringLog stringlog = new StringLog();

    public void Log(string[] args, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = null)
    {

      this.SetColor(ConsoleColor.White);
      string[] newargs = PrependLogWithMessageType(args, $"{line}:{caller}(Message) =>");
      stringlog.LogsOnMultiLine(newargs, "", this.color);
      this.RemoveColor();
    }

    public void Warn(string[] args, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = null)
    {

      this.SetColor(ConsoleColor.Yellow);
      string[] newargs = PrependLogWithMessageType(args, $"{line}:{caller}(Warning) =>");
      stringlog.LogsOnMultiLine(newargs, "", this.color);
      this.RemoveColor();
    }

    public void Error(string[] args, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = null)
    {

      this.SetColor(ConsoleColor.Red);
      string[] newargs = PrependLogWithMessageType(args, $"{line}:{caller}(Error) =>");
      stringlog.LogsOnMultiLine(newargs, "", this.color);
      this.RemoveColor();
    }

    public void Success(string[] args, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = null)
    {

      this.SetColor(ConsoleColor.Green);
      string[] newargs = PrependLogWithMessageType(args, $"{line}:{caller}(Success) =>");
      stringlog.LogsOnMultiLine(newargs, "", this.color);
      this.RemoveColor();
    }

    public void Log(string[] args, string seperation, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = null)
    {
      this.SetColor(ConsoleColor.White);
      string[] newargs = PrependLogWithMessageType(args, $"{line}:{caller}(Message) =>");
      stringlog.LogsOnSingleLine(newargs, seperation, this.color);
      this.RemoveColor();
    }

    public void Warn(string[] args, string seperation, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = null)
    {
      this.SetColor(ConsoleColor.Yellow);
      string[] newargs = PrependLogWithMessageType(args, $"{line}:{caller}(Warning) =>");
      stringlog.LogsOnSingleLine(newargs, seperation, this.color);
      this.RemoveColor();
    }

    public void Error(string[] args, string seperation, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = null)
    {
      this.SetColor(ConsoleColor.Red);
      string[] newargs = PrependLogWithMessageType(args, $"{line}:{caller}(Error) =>");
      stringlog.LogsOnSingleLine(newargs, seperation, this.color);
      this.RemoveColor();
    }

    public void Success(string[] args, string seperation, [CallerLineNumber] int line = 0, [CallerMemberName] string caller = null)
    {
      this.SetColor(ConsoleColor.Green);
      string[] newargs = PrependLogWithMessageType(args, $"{line}:{caller}(Success) =>");
      stringlog.LogsOnSingleLine(newargs, seperation, this.color);
      this.RemoveColor();
    }

    private void SetColor(ConsoleColor color)
    {
      this.color = color;
    }

    private void RemoveColor()
    {
      this.color = ConsoleColor.White;
    }

    private string[] PrependLogWithMessageType(string[] args, string message)
    {
      string[] newStringArray = new string[args.Length + 1];
      newStringArray[0] = message;
      Array.Copy(args, 0, newStringArray, 1, args.Length);
      return newStringArray;
    }

    /**
    Takes unlimited number of strings as parameters and returns them back in the string format needed for all logging calls
     */
    public string[] Map(params string[] messages) { return messages; }
    public string[] Map(params char[] messages)
    {
      string[] message = new string[messages.Length];
      for (int i = 0; i < messages.Length; i++) message[i] = messages[i].ToString();
      return message;
    }
    public string[] Map(params double[] messages)
    {
      string[] message = new string[messages.Length];
      for (int i = 0; i < messages.Length; i++) message[i] = messages[i].ToString();
      return message;
    }
    public string[] Map(params float[] messages)
    {
      string[] message = new string[messages.Length];
      for (int i = 0; i < messages.Length; i++) message[i] = messages[i].ToString();
      return message;
    }
    public string[] Map(params int[] messages)
    {
      string[] message = new string[messages.Length];
      for (int i = 0; i < messages.Length; i++) message[i] = messages[i].ToString();
      return message;
    }

  }
}