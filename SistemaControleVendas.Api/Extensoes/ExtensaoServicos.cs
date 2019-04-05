using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SistemaControleVendas.Dominio.Contratos;
using SistemaControleVendas.Dominio.Contratos.Servicos;
using SistemaControleVendas.Infra.ContextoDeDados;
using SistemaControleVendas.Infra.Repositorios;
using SistemaControleVendas.Servicos.Servicos;
using Swashbuckle.AspNetCore.Swagger;

namespace SistemaControleVendas.Api.Extensoes
{
    public static class ExtensaoServicos
    {

        //Configuracão der cors para que uma origem diferente possa acessar minha api no caso minha aplicação angular
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            options.AddPolicy("Policy", build =>
             build.AllowAnyHeader()
             .AllowAnyMethod()
             .AllowAnyOrigin()
             .AllowCredentials()));
        }

        //configuracoes para pode ultitliza a injecao de dependencia
        public static void ConfigureRepositorio(this IServiceCollection services)
        {
            services.AddScoped<DbSistemaControleVendas, DbSistemaControleVendas>();

            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<IVendaRepositorio, VendaRepositorio>();
            services.AddScoped<IVendaService, VendaService>();

            services.AddScoped<IVendedorRepositorio, VendedorRepositorio>();
            services.AddScoped<IVendedorService, VendedorService>();

        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Sistema controle de vendas", Version = "v1" });
            });
        }

    }
}
