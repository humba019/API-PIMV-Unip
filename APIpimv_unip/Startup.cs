using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using APIpimv_unip.Persistence.Contexts;
using APIpimv_unip.Persistence.Repositories;
using APIpimv_unip.Repositories;
using APIpimv_unip.Services;
using AutoMapper;
using APIpimv_unip.Services.Interfaces;

namespace APIpimv_unip
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
            services.AddDbContext<AppDbContext>(opt => {
                opt.UseInMemoryDatabase("pimv");
             });

            services.AddScoped<IAdvertenciaRepository, AdvertenciaRepository>();
            services.AddScoped<IAulaRepository, AulaRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
            services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IPeriodoRepository, PeriodoRepository>();
            services.AddScoped<ISetorRepository, SetorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAdvertenciaService, AdvertenciaService>();
            services.AddScoped<IAulaService, AulaService>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();
            services.AddScoped<IEmprestimoService, EmprestimoService>();
            services.AddScoped<IEquipamentoService, EquipamentoService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<IPeriodoService, PeriodoService>();
            services.AddScoped<ISetorService, SetorService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddAutoMapper(typeof(Startup));
            services.AddHealthChecks();
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
        }
    }
}
