using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System;

public class DeveloperConsole : MonoBehaviour
{
    static DeveloperConsole instance;
    public static DeveloperConsole Instance => Singleton.GetInstance(ref instance);
    Console console;

    struct Action
    {
        public object obj;
        public MethodInfo method;
    }
    Dictionary<string, Action> actions=new Dictionary<string, Action>();

    public static void Register(object obj)
    {
        MethodInfo[] methods = obj.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        foreach (var method in methods)
        {
            ConsoleAttribute attribute = method.GetCustomAttribute<ConsoleAttribute>();
            if (attribute != null)
            {
                Instance.actions[method.Name] = new Action { obj = obj, method = method };
            }
        }
    }
    
    void Start()
    {
        Singleton.Initialize(this, ref instance);
        console = GetComponent<Console>();
        console.onInput.AddListener(OnInput);
    }

    void OnInput(string text)
    {
        try
        {
            object result = ExecuteCommand(text);
            if (result != null)
            {
                console.Write(result.ToString());
            }
        }
        catch (CommandException e)
        {
            console.Write("ERROR: " + e.Message);
        }
    }

    class CommandException : Exception {
        public CommandException(string message) : base(message) { }
    }

    object ExecuteCommand(string text)
    {
        string[] parts = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0)
        {
            return null;
        }
        if (!actions.ContainsKey(parts[0]))
        {
            throw new CommandException("No such function registered");
        }
        Action action = actions[parts[0]];
        ParameterInfo[] parameters = action.method.GetParameters();
        if (parameters.Length != parts.Length-1)
        {
            throw new CommandException("Wrong amount of arguments, expected " + parameters.Length);
        }
        object[] parameterValues = new object[parameters.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
            parameterValues[i] = Convert.ChangeType(parts[1 + i], parameters[i].ParameterType);
        }
        return action.method.Invoke(action.obj, parameterValues);
    }
}
