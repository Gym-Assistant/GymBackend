using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using Saritasa.Tools.Common.Utils;

namespace GymBackend.UseCases.Common.BaseHandlers;

/// <summary>
/// Base logic for commands.
/// </summary>
public abstract class BaseCommandHandler
{
    /// <summary>
    /// Automapper.
    /// </summary>
    protected IMapper Mapper { get; }

    /// <summary>
    /// Database context.
    /// </summary>
    protected IAppDbContext DbContext { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public BaseCommandHandler(IMapper mapper, IAppDbContext dbContext)
    {
        Guard.IsNotNull(mapper, nameof(mapper));
        Guard.IsNotNull(dbContext, nameof(dbContext));

        Mapper = mapper;
        DbContext = dbContext;
    }
}
