public interface TimoModule
{
    void OnTaskSatisfied();

    void AddTaskToQueue(Task t);
}