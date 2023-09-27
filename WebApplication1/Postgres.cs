using FluentMigrator.Runner;
using Microsoft.Extensions.Options;
using Npgsql;
using Npgsql.NameTranslation;
using WebApplication1.Entities;

namespace WebApplication1;

public static class Postgres
{
    private static readonly INpgsqlNameTranslator Translator = new NpgsqlSnakeCaseNameTranslator();

    /// <summary>
    /// Map DAL models to composite types (enables UNNEST)
    /// </summary>
    public static void MapCompositeTypes()
    {
        var mapper = NpgsqlConnection.GlobalTypeMapper;
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        
        mapper.MapComposite<Article>("article", Translator);
        mapper.MapComposite<Tag>("tag", Translator);
    }

    /// <summary>
    /// Add migration infrastructure
    /// </summary>
    public static void AddMigrations(IServiceCollection services)
    {
        services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb.AddPostgres()
                .WithGlobalConnectionString(s =>
                {
                    var cfg = s.GetRequiredService<IOptions<DalOptions>>();
                    return cfg.Value.ConnectionString;
                })
                .ScanIn(typeof(Postgres).Assembly).For.Migrations()
            )
            .AddLogging(lb => lb.AddFluentMigratorConsole());
    }
}