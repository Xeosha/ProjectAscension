﻿using CSharpFunctionalExtensions;
using GameService.CORE.Common;

namespace GameService.CORE.Interfaces.Abstractions
{
    public interface ICommandHandler<TResponse, in TCommand> where TCommand : ICommand
    {
        public Task<Result<TResponse, ErrorList>> Handle(TCommand command, CancellationToken cancellationToken = default);
    }

    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        public Task<UnitResult<ErrorList>> Handle(TCommand command, CancellationToken cancellationToken = default);
    }
}
