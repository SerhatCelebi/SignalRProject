using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using SignalRApi.Hubs;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host)=>true)
        .AllowCredentials();
    });
});
builder.Services.AddSignalR();

// Add services to the container.

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//About Cont
builder.Services.AddScoped<IAboutService,AboutManager>();
builder.Services.AddScoped<IAboutDal,EfAboutDal>();

//Booking Cont
builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();

//Category Cont
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

//Contact Cont
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

//Discount Cont
builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();

//Feature Cont
builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();

//Product Cont
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();

//SocialMedia Cont
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

//Testimonial Cont
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
