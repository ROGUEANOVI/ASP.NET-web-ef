using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEF.DbContexts;


var builder = WebApplication.CreateBuilder(args);

// ####### Configuracion de Entity Framework (Base de datos en memoria) #######
// builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TaskDB"));

builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("CsTasksDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", ([FromServices] TaskContext dbContext) =>
    {
      dbContext.Database.EnsureCreated();
      return Results.Ok("Base de datos en memoria:" + dbContext.Database.IsInMemory());
    }
);

app.MapGet("/api/tasks", ([FromServices] TaskContext dbContext) =>

  {
    return Results.Ok(dbContext.Tasks);
  }

);

app.MapGet("/api/tasks/{id}", async ([FromServices] TaskContext dbContext, [FromRoute] Guid id) =>

  {
    var task = await dbContext.Tasks!.FindAsync(id);
    if (task != null)
    {
      return Results.Ok(task);
    }

    return Results.NotFound();
  }

);

app.MapPost("/api/tasks",  async ([FromServices] TaskContext dbContext, [FromBody] WebEF.Models.Task task) =>
  {
    task.TaskId = Guid.NewGuid();
    task.CreationDate = DateTime.Now;
    await dbContext.AddAsync(task);
    // await dbContext.Tasks!.AddAsync(task);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
  }
);


app.MapPut("/api/tasks/{id}", async ([FromServices] TaskContext dbContext, [FromBody] WebEF.Models.Task task, [FromRoute] Guid id) =>
  {
    var currentTask = await dbContext.Tasks!.FindAsync(id);

    if (currentTask != null)
    {
      currentTask.Title = task.Title;
      currentTask.Description = task.Description;
      currentTask.TaskPriority = task.TaskPriority;    
      currentTask.CategoryId = task.CategoryId;

      await dbContext.SaveChangesAsync();

      return Results.Ok();
    }

    return Results.NotFound();
  }
);

app.MapDelete("/api/tasks/{id}", async ([FromServices] TaskContext dbContext, [FromRoute] Guid id) =>
  {
    var currentTask = await dbContext.Tasks!.FindAsync(id);

    if (currentTask != null)
    {
      dbContext.Remove(currentTask);
      
      await dbContext.SaveChangesAsync();

      return Results.Ok();
    }

    return Results.NotFound();
  }
);


app.Run();
