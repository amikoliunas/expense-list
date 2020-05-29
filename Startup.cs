using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using ExpensesWebApp.Utilities;

namespace ExpensesWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton(typeof(IConnectionToDB), typeof(ConnectionToDB));
            services.AddTransient(typeof(IExpenseManager), typeof(ExpenseManager));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InitializeDatabase();
        }
        public void InitializeDatabase()
        {

            var assembly = Assembly.GetExecutingAssembly();
            var allResourceNames = assembly.GetManifestResourceNames();
            var resourceName = allResourceNames[0];

            using var conn = new SqlConnection(Configuration.GetConnectionString("DatabaseConnectionString"));
            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream);
            conn.Open();
            string sqlscript = reader.ReadToEnd();
            var sqlqueries = sqlscript.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
            var cmd = new SqlCommand("query", conn);
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
