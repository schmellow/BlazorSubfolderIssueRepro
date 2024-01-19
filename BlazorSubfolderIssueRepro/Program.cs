using BlazorSubfolderIssueRepro.Components;

namespace BlazorSubfolderIssueRepro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? basePath = builder.Configuration.GetValue<string>("BasePath");
            if (string.IsNullOrEmpty(basePath))
                basePath = "/";

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            var app = builder.Build();
            app.UseForwardedHeaders();
            if (!app.Environment.IsDevelopment())
                app.UseExceptionHandler("/Error");
            if (basePath != "/")
                app.UsePathBase(basePath);
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
