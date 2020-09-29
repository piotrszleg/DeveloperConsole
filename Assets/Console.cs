using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System;
using System.Linq;

public class Console : MonoBehaviour
{
    static Console instance;
    public static Console Instance => Singleton.GetInstance(ref instance);
    ConsoleUI console;

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

    public static void Unregister(object obj)
    {
        if (instance == null)
            return;

        instance.actions = Instance.actions
            .Where(pair => pair.Value.obj != obj)
            .ToDictionary(pair=>pair.Key, pair=>pair.Value);
    }

    [Console]
    void Help()
    {
        console.Write("Available commands are:");
        foreach(var pair in instance.actions)
        {
            console.Write(pair.Value.method.ToString());
        }
    }

    void Start()
    {
        Singleton.Initialize(this, ref instance);
        console = GetComponent<ConsoleUI>();
        console.onInput.AddListener(OnInput);
        Register(this);
    }

    void OnDestroy()
    {
        Console.Unregister(this);
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
            console.Write($"<color=red>{e.Message}</color>");
        }
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
        int expectedArgumentsCount = parts.Length - 1;
        if (parameters.Length != expectedArgumentsCount)
        {
            throw new CommandException($"Wrong number of arguments, expected {parameters.Length}, got {expectedArgumentsCount}.");
        }
        object[] parameterValues = new object[parameters.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
            parameterValues[i] = Convert.ChangeType(parts[1 + i], parameters[i].ParameterType);
        }
        return action.method.Invoke(action.obj, parameterValues);
    }

    class CommandException : Exception {
        public CommandException(string message) : base(message) { }
    }
}
