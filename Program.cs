var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

var tasks = new List<TodoItem>();

app.MapGet("/tasks", () => tasks);

app.MapPost("/tasks", (TodoItem task) => {
    task.Id = tasks.Count + 1;
    tasks.Add(task);
    return Results.Created($"/tasks/{task.Id}", task);
});

app.Run();

public class TodoItem {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; }
}
