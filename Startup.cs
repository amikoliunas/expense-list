using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Diagnostics;

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

            ConnectAndCreate();
        }
        public void ConnectAndCreate()
        {
            string connetionString = Configuration.GetConnectionString("MyConnStr");
            SqlConnection cnn;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            var assembly = Assembly.GetExecutingAssembly();
            var allResourceNames = assembly.GetManifestResourceNames();
            var resourceName = allResourceNames[0];
            {
                Stream stream = assembly.GetManifestResourceStream(resourceName);
                StreamReader reader = new StreamReader(stream);
                try
                    {
                        string sqlscript = reader.ReadToEnd();
                        var sqlqueries = sqlscript.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
                        var cmd = new SqlCommand("query", cnn);
                        foreach (var query in sqlqueries)
                        {
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();
                        }
                    }
                finally
                {
                    ((IDisposable)reader).Dispose();
                    ((IDisposable)stream).Dispose();
                }
            }
            cnn.Close();
        }
    }
}
