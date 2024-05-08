using ASP_LR2;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Use(async (context, next) => {
    context.Response.ContentType = "text/plain; charset=utf-8";
    await next();
});

var basePath = Environment.CurrentDirectory;

builder.Configuration.AddXmlFile(Path.Combine(basePath, "microsoft.xml"));
builder.Configuration.AddIniFile(Path.Combine(basePath, "google.ini"));
builder.Configuration.AddJsonFile(Path.Combine(basePath, "apple.json"));
builder.Configuration.AddJsonFile(Path.Combine(basePath, "person.json"));

var microsoft = new Company();
var google = new Company();
var apple = new Company();
var person = new Person();

app.Configuration.Bind(microsoft);
app.Configuration.Bind("Google", google);
app.Configuration.Bind("Apple", apple);
app.Configuration.Bind("Person", person);

app.Run(async (context) => {
    await context.Response.WriteAsync($"Кількість людей у компанії:\n");
    await context.Response.WriteAsync($"{microsoft.name} - {microsoft.humans}\n");
    await context.Response.WriteAsync($"{google.name} - {google.humans}\n");
    await context.Response.WriteAsync($"{apple.name} - {apple.humans}\n");

    string companyWithMaxHumans = Company.GetCompanyWithMaxHumans(microsoft, apple, google);
    await context.Response.WriteAsync($"Найбільша кількість людей у компанії: {companyWithMaxHumans}\n");

    await context.Response.WriteAsync($"\nОсобиста інформація:\nІм'я: {person.name}\nВік: {person.age}\nРобота: {person.job}");
});

app.Run();
