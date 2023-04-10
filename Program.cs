List<string> TaskList = new List<string>();
int menuSelected = 0;

do { 
        
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowMenuTaskList();
    }
} while ((Menu)menuSelected != Menu.Exit);

int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    // Read line
    string optionSelected = Console.ReadLine();
    if(Char.IsDigit(Char.Parse(optionSelected)))
    {
        return Convert.ToInt32(optionSelected);
    }
    Console.WriteLine("Opción seleccionada no es correcta");
    return -1;
}

void ShowMenuRemove()
{
    Console.WriteLine("Ingrese el número de la tarea a remover: ");
    // Show current taks
    ShowMenuTaskList();

    string taskToRemoveId = Console.ReadLine();
    if (taskToRemoveId.Length == 1 && Char.IsNumber(Char.Parse(taskToRemoveId)))
    {
        // Remove one position
        int indexToRemove = Convert.ToInt32(taskToRemoveId) - 1;
        if (TaskList.Count > 0 && indexToRemove > -1 && indexToRemove <= TaskList.Count - 1)
        {
            string task = TaskList[indexToRemove];
            TaskList.RemoveAt(indexToRemove);
            Console.WriteLine($"Tarea {task} eliminada.");
        }
        else
        {
            Console.WriteLine("Identificador de tarea no válido.");
        }
    }
    else
    {
        Console.WriteLine("No has introducido ninguna tarea válida");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string newTask = Console.ReadLine();
        TaskList.Add(newTask);
        Console.WriteLine("Tarea registrada");
    }
    catch (Exception)
    {
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        Console.WriteLine("----------------------------------------");
        var indexTask = 0;
        TaskList.ForEach(task => Console.WriteLine($"{++indexTask}. {task}"));
        Console.WriteLine("----------------------------------------");
    } 
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
