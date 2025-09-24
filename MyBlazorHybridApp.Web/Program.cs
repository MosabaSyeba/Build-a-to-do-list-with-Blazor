using MyBlazorHybridApp.Shared.Services;
using MyBlazorHybridApp.Web.Components;
using MyBlazorHybridApp.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Tambahkan layanan komponen Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// ✅ Registrasi service shared (jika kamu punya implementasi FormFactor)
builder.Services.AddSingleton<IFormFactor, FormFactor>();

var app = builder.Build();

// ✅ Konfigurasi pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();            // ✅ Harus sebelum UseAntiforgery dan MapRazorComponents
app.UseAntiforgery();        // ✅ Harus setelah UseRouting()

// ✅ Penting: panggil MapStaticAssets sebelum MapRazorComponents
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(MyBlazorHybridApp.Shared._Imports).Assembly,
        typeof(MyBlazorHybridApp.Web.Client._Imports).Assembly);

app.Run();
