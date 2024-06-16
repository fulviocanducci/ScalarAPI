using AspNetCore.Scalar;
namespace Web;
public class Program
{
   public static void Main(string[] args)
   {
      var builder = WebApplication.CreateBuilder(args);
      builder.Services.AddControllers().AddNewtonsoftJson();

      builder.Services.Configure<RouteOptions>(options =>
      {
         options.LowercaseUrls = true;
         options.LowercaseQueryStrings = true;
      });

      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen(options => { });
      var app = builder.Build();

      if (app.Environment.IsDevelopment())
      {
         app.UseSwagger(options =>
         {

         });
         app.UseScalar(options =>
         {
            options.UseTheme(Theme.Alternate);
            options.UseLayout(Layout.Classic);
            options.RoutePrefix = "scalar";
            options.DocumentTitle = "API With Scalar";
         });
      }
      app.UseHttpsRedirection();
      app.UseAuthorization();
      app.MapControllers();
      app.Run();
   }
}