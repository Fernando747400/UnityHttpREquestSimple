using System;

[Serializable]
public class TodoItemModel
{
    public int TodoItemId;
    public string Name;
    public bool IsComplete;

    public TodoItemModel(string name, bool isComplete)
    {
        Name = name;
        IsComplete = isComplete;
    }

    public TodoItemModel(int iD, string name, bool isComplete)
    {
        TodoItemId = iD;
        Name = name;
        IsComplete = isComplete;
    }
}
