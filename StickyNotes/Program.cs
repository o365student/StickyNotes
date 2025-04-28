using Microsoft.EntityFrameworkCore;
using StickyNotes.Data;

var builder = WebApplication.CreateBuilder(args);

// ① 加入 MVC
builder.Services.AddControllersWithViews();

// ② 註冊 DbContext（含自動重試）
builder.Services.AddDbContext<StickyNotesContext>(opt =>
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("StickyNotesConn"),
        sql => sql.EnableRetryOnFailure()
    )
);

var app = builder.Build();

// ③ 在啟動時自動套用 Migration（避免 Azure 上沒有 Notes 表）
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StickyNotesContext>();
    db.Database.Migrate();      // 若不存在 DB/schema 會自動建立
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Notes}/{action=Index}/{id?}");

app.Run();
