
using EmployeeManagement.Service.BusinessLogic.Interface;
using EmployeeManagement.Service.BusinessLogic.Service;
using EmployeeManagement.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<IPartnerApiService,PartnerApiService>();

builder.Services.AddSingleton(typeof(IEmployeeService), typeof(EmployeeService));
builder.Services.AddSingleton(typeof(IProductOrderService), typeof(ProductOrderService));
builder.Services.AddSingleton(typeof(IPurchaseService), typeof(PurchaseService));
builder.Services.AddSingleton(typeof(ISaleService), typeof(SaleService));
builder.Services.AddSingleton(typeof(IOrderService), typeof(OrderService));
builder.Services.AddSingleton(typeof(ISupportTicketService), typeof(SupportTicketService));
builder.Services.AddSingleton(typeof(IInquiryService), typeof(InquiryService));
builder.Services.AddSingleton(typeof(ICustomerActivityService), typeof(CustomerActivityService));
builder.Services.AddSingleton(typeof(IApplicationDataService), typeof(ApplicationDataService));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandlingMiddleware();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseLoggingMiddleware();
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
